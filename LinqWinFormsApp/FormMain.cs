using System.Globalization;

namespace LinqWinFormsApp;

public partial class FormMain : Form
{
    private readonly List<Category> _categories;
    private readonly List<Order> _orders;

    private int _currentPage = 1;
    private int _totalPages = 1;

    // Константы режимов работы
    private const string MODE_JOIN = "1. Внутреннее соединение (Join) со скидками";
    private const string MODE_GROUP_JOIN = "2. Групповое соединение (GroupJoin) по категориям";
    private const string MODE_GROUP_BY = "3. Группировка с итогами (GroupBy) и фильтром выручки";
    private const string MODE_TOP3 = "4. ТОП-3 самых дорогих заказа (Take(3))";
    private const string MODE_SLICE = "5. Срез списка (Пропуск N устаревших заказов: Skip(N))";
    private const string MODE_PAGING = "6. Постраничный просмотр (Paging: Skip и Take)";

    public FormMain()
    {
        InitializeComponent();

        // Загрузка связанных коллекций
        _categories = DataRepository.GetCategories();
        _orders = DataRepository.GetOrders();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
        // Настройка выпадающего списка операций
        cmbOperation.Items.AddRange(new object[]
        {
            MODE_JOIN,
            MODE_GROUP_JOIN,
            MODE_GROUP_BY,
            MODE_TOP3,
            MODE_SLICE,
            MODE_PAGING
        });

        cmbOperation.SelectedIndex = 0; // По умолчанию Задание 1.1 (Join)
    }

    /// <summary>
    /// Смена выбранного режима анализа данных
    /// </summary>
    private void CmbOperation_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateControlVisibility();
        ExecuteSelectedQuery();
    }

    /// <summary>
    /// Управление видимостью и доступностью вспомогательных контролов в зависимости от режима
    /// </summary>
    private void UpdateControlVisibility()
    {
        var selectedMode = cmbOperation.SelectedItem?.ToString() ?? string.Empty;

        // Порог выручки активен только при GroupBy
        lblThreshold.Visible = selectedMode == MODE_GROUP_BY;
        numThreshold.Visible = selectedMode == MODE_GROUP_BY;

        // Поле пропуска N активно только при Срезе
        lblSkipCount.Visible = selectedMode == MODE_SLICE;
        numSkipCount.Visible = selectedMode == MODE_SLICE;

        btnApplyFilter.Visible = (selectedMode == MODE_GROUP_BY || selectedMode == MODE_SLICE);

        // Панель пагинации активна и акцентирована при постраничном просмотре
        pnlPaging.Visible = (selectedMode == MODE_PAGING);
    }

    /// <summary>
    /// Выполнение соответствующего LINQ-запроса и привязка к DataGridView
    /// </summary>
    private void ExecuteSelectedQuery()
    {
        var selectedMode = cmbOperation.SelectedItem?.ToString();

        switch (selectedMode)
        {
            case MODE_JOIN:
                ExecuteJoinQuery();
                break;

            case MODE_GROUP_JOIN:
                ExecuteGroupJoinQuery();
                break;

            case MODE_GROUP_BY:
                ExecuteGroupByQuery();
                break;

            case MODE_TOP3:
                ExecuteTop3Query();
                break;

            case MODE_SLICE:
                ExecuteSliceQuery();
                break;

            case MODE_PAGING:
                ExecutePagingQuery();
                break;
        }

        FormatGridColumns();
    }

    // =========================================================================
    // Реализация вызовов LINQ для каждого режима
    // =========================================================================

    /// <summary>
    /// Задание 1.1: Join (Внутреннее соединение)
    /// </summary>
    private void ExecuteJoinQuery()
    {
        var result = LinqService.GetOrdersWithCategoryDiscount(_orders, _categories);

        dgvResults.DataSource = null;
        dgvResults.DataSource = result;

        var totalOriginal = result.Sum(x => x.Amount);
        var totalDiscounted = result.Sum(x => x.DiscountedAmount);
        var economy = totalOriginal - totalDiscounted;

        lblSummary.Text = $"Заказов: {result.Count} шт. | " +
                          $"Сумма до скидки: {totalOriginal:N2} ₽ | " +
                          $"Сумма со скидкой: {totalDiscounted:N2} ₽ | " +
                          $"Экономия клиентов: {economy:N2} ₽";
    }

    /// <summary>
    /// Задание 1.2: GroupJoin (Групповое соединение)
    /// </summary>
    private void ExecuteGroupJoinQuery()
    {
        var result = LinqService.GetCategoriesWithOrdersSummary(_categories, _orders);

        dgvResults.DataSource = null;
        dgvResults.DataSource = result;

        var totalOrders = result.Sum(x => x.OrdersCount);
        var totalRevenue = result.Sum(x => x.TotalRevenue);
        var emptyCategories = result.Count(x => x.OrdersCount == 0);

        lblSummary.Text = $"Категорий: {result.Count} | " +
                          $"Всего заказов: {totalOrders} | " +
                          $"Общая выручка: {totalRevenue:N2} ₽ | " +
                          $"Категорий без заказов (пустые группы): {emptyCategories}";
    }

    /// <summary>
    /// Задание 2: GroupBy с фильтрацией по порогу выручки
    /// </summary>
    private void ExecuteGroupByQuery()
    {
        var minThreshold = numThreshold.Value;
        var result = LinqService.GetCategoryGroupStats(_orders, _categories, minThreshold);

        dgvResults.DataSource = null;
        dgvResults.DataSource = result;

        var totalRev = result.Sum(x => x.TotalRevenue);
        var totalOrders = result.Sum(x => x.OrdersCount);

        lblSummary.Text = $"Групп с выручкой >= {minThreshold:N0} ₽: {result.Count} | " +
                          $"Заказов в отфильтрованных группах: {totalOrders} | " +
                          $"Итоговая выручка: {totalRev:N2} ₽";
    }

    /// <summary>
    /// Задание 3.2: ТОП-3 самых дорогих заказа
    /// </summary>
    private void ExecuteTop3Query()
    {
        var result = LinqService.GetTop3ExpensiveOrders(_orders, _categories);

        dgvResults.DataSource = null;
        dgvResults.DataSource = result;

        var sumTop = result.Sum(x => x.Amount);
        var maxOrder = result.FirstOrDefault()?.Amount ?? 0m;

        lblSummary.Text = $"ТОП-3 заказа | Максимальный чек: {maxOrder:N2} ₽ | " +
                          $"Сумма ТОП-3: {sumTop:N2} ₽";
    }

    /// <summary>
    /// Задание 3.3: Срез списка (пропуск N устаревших заказов)
    /// </summary>
    private void ExecuteSliceQuery()
    {
        var skipCount = (int)numSkipCount.Value;
        var result = LinqService.SkipOutdatedOrders(_orders, _categories, skipCount);

        dgvResults.DataSource = null;
        dgvResults.DataSource = result;

        var sumRemaining = result.Sum(x => x.Amount);

        lblSummary.Text = $"Пропущено первых {skipCount} устаревших заказов | " +
                          $"Осталось заказов: {result.Count} из {_orders.Count} | " +
                          $"Сумма оставшихся: {sumRemaining:N2} ₽";
    }

    /// <summary>
    /// Задание 3.1: Пейджинг (Paging: Skip и Take)
    /// </summary>
    private void ExecutePagingQuery()
    {
        var pageSize = (int)numPageSize.Value;

        var (items, totalRecords, totalPages, currentPage) =
            LinqService.GetPagedOrders(_orders, _categories, _currentPage, pageSize);

        _totalPages = totalPages;
        _currentPage = currentPage;

        dgvResults.DataSource = null;
        dgvResults.DataSource = items;

        // Обновление состояния элементов навигации
        lblPageInfo.Text = $"Страница {_currentPage} из {_totalPages} (Всего: {totalRecords} записей)";
        btnPrev.Enabled = (_currentPage > 1);
        btnNext.Enabled = (_currentPage < _totalPages);

        var pageSum = items.Sum(x => x.Amount);

        lblSummary.Text = $"Постраничный вывод: Записей на странице: {items.Count} | " +
                          $"Сумма на текущей странице: {pageSum:N2} ₽ | " +
                          $"Всего страниц: {_totalPages}";
    }

    // =========================================================================
    // События навигации и фильтрации
    // =========================================================================

    private void BtnPrev_Click(object sender, EventArgs e)
    {
        if (_currentPage > 1)
        {
            _currentPage--;
            ExecutePagingQuery();
            FormatGridColumns();
        }
    }

    private void BtnNext_Click(object sender, EventArgs e)
    {
        if (_currentPage < _totalPages)
        {
            _currentPage++;
            ExecutePagingQuery();
            FormatGridColumns();
        }
    }

    private void NumPageSize_ValueChanged(object sender, EventArgs e)
    {
        _currentPage = 1; // Сброс на первую страницу при смене размера
        if (cmbOperation.SelectedItem?.ToString() == MODE_PAGING)
        {
            ExecutePagingQuery();
            FormatGridColumns();
        }
    }

    private void FilterParams_Changed(object sender, EventArgs e)
    {
        // Автоматически или по кнопке обновляем
        ExecuteSelectedQuery();
    }

    private void BtnApplyFilter_Click(object sender, EventArgs e)
    {
        ExecuteSelectedQuery();
    }

    /// <summary>
    /// Наведение красоты в DataGridView: форматирование денежных сумм, дат и выравнивание
    /// </summary>
    private void FormatGridColumns()
    {
        foreach (DataGridViewColumn col in dgvResults.Columns)
        {
            // Форматирование сумм
            if (col.Name.Contains("Amount") || col.Name.Contains("Revenue") || col.Name.Contains("Check"))
            {
                col.DefaultCellStyle.Format = "N2";
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            // Форматирование дат
            else if (col.Name.Contains("Date"))
            {
                col.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            // Числовые счетчики и ID
            else if (col.Name.Contains("Id") || col.Name.Contains("Count"))
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else if (col.Name.Contains("Percent"))
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}
