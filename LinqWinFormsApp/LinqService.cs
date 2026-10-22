namespace LinqWinFormsApp;

public static class LinqService
{
    // =========================================================================
    // ЗАДАНИЕ 1. Соединение коллекций (Join и GroupJoin)
    // =========================================================================

    /// <summary>
    /// 1.1 Внутреннее соединение (Join):
    /// Соединяет заказы с категориями по CategoryId == Category.Id.
    /// Формирует проекцию: Клиент, Категория, Сумма, Скидка, Сумма со скидкой.
    /// </summary>
    public static List<OrderJoinDiscountDto> GetOrdersWithCategoryDiscount(
        IEnumerable<Order> orders,
        IEnumerable<Category> categories)
    {
        return orders.Join(
            categories,
            order => order.CategoryId,
            category => category.Id,
            (order, category) => new OrderJoinDiscountDto
            {
                OrderId = order.Id,
                CustomerName = order.CustomerName,
                CategoryName = category.Name,
                Amount = order.Amount,
                DiscountRate = category.DiscountRate,
                // Вычисление итоговой суммы с учетом скидки категории
                DiscountedAmount = Math.Round(order.Amount * (1m - (decimal)category.DiscountRate), 2),
                OrderDate = order.OrderDate
            })
            .OrderBy(x => x.OrderId)
            .ToList();
    }

    /// <summary>
    /// 1.2 Групповое соединение (GroupJoin):
    /// Для каждой категории получает список всех относящихся к ней заказов.
    /// Выводит название категории и общее количество заказов в ней.
    /// ВАЖНО: Гарантированно обрабатывает пустые группы (категории без заказов).
    /// </summary>
    public static List<CategoryGroupJoinDto> GetCategoriesWithOrdersSummary(
        IEnumerable<Category> categories,
        IEnumerable<Order> orders)
    {
        return categories.GroupJoin(
            orders,
            category => category.Id,
            order => order.CategoryId,
            (category, categoryOrders) =>
            {
                // categoryOrders - это IEnumerable<Order> для текущей категории
                var orderList = categoryOrders.ToList();
                return new CategoryGroupJoinDto
                {
                    CategoryId = category.Id,
                    CategoryName = category.Name,
                    DiscountRate = category.DiscountRate,
                    // Если заказов нет, Count() вернет 0 (защита от пустых групп)
                    OrdersCount = orderList.Count,
                    TotalRevenue = orderList.Any() ? orderList.Sum(o => o.Amount) : 0m
                };
            })
            .OrderBy(c => c.CategoryId)
            .ToList();
    }

    // =========================================================================
    // ЗАДАНИЕ 2. Группировка данных (GroupBy)
    // =========================================================================

    /// <summary>
    /// Задание 2: Сгруппировать заказы по ID категории (GroupBy(o => o.CategoryId)).
    /// Для каждой группы вычисляет: ID группы, Количество заказов, Общую сумму (Sum), Средний чек (Average).
    /// Фильтрует группы, где суммарная выручка превышает заданный порог.
    /// </summary>
    public static List<CategoryGroupStatsDto> GetCategoryGroupStats(
        IEnumerable<Order> orders,
        IEnumerable<Category> categories,
        decimal minRevenueThreshold = 0m)
    {
        var categoryNames = categories.ToDictionary(c => c.Id, c => c.Name);

        return orders
            .GroupBy(o => o.CategoryId)
            .Select(g => new CategoryGroupStatsDto
            {
                CategoryId = g.Key,
                CategoryName = categoryNames.TryGetValue(g.Key, out var name) ? name : $"Категория #{g.Key}",
                OrdersCount = g.Count(),
                TotalRevenue = g.Sum(o => o.Amount),
                // Защита от деления на 0 при пустых группах:
                AverageCheck = g.Any() ? Math.Round(g.Average(o => o.Amount), 2) : 0m
            })
            .Where(g => g.TotalRevenue >= minRevenueThreshold)
            .OrderByDescending(g => g.TotalRevenue)
            .ToList();
    }

    // =========================================================================
    // ЗАДАНИЕ 3. Постраничный вывод и выборка частей (Take и Skip)
    // =========================================================================

    /// <summary>
    /// 3.1 Пейджинг (Paging):
    /// Получение указанной страницы заказов по формуле:
    /// orders.Skip((pageNumber - 1) * pageSize).Take(pageSize)
    /// С точным расчетом страниц и без загрузки лишних данных в память.
    /// </summary>
    public static (List<OrderDisplayDto> Items, int TotalRecords, int TotalPages, int CurrentPage) GetPagedOrders(
        IEnumerable<Order> orders,
        IEnumerable<Category> categories,
        int requestedPageNumber,
        int pageSize)
    {
        var categoryMap = categories.ToDictionary(c => c.Id, c => c.Name);
        var totalRecords = orders.Count();

        if (pageSize < 1) pageSize = 5;
        var totalPages = (int)Math.Max(1, Math.Ceiling((double)totalRecords / pageSize));

        // Корректная валидация номера страницы во избежание штрафных санкций
        var currentPage = Math.Clamp(requestedPageNumber, 1, totalPages);

        // Точечная выборка строго через Skip и Take:
        var pagedList = orders
            .OrderBy(o => o.Id) // Фиксированный порядок для консистентного пейджинга
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .Select(o => new OrderDisplayDto
            {
                Id = o.Id,
                CustomerName = o.CustomerName,
                CategoryId = o.CategoryId,
                CategoryName = categoryMap.TryGetValue(o.CategoryId, out var catName) ? catName : $"#{o.CategoryId}",
                Amount = o.Amount,
                OrderDate = o.OrderDate
            })
            .ToList();

        return (pagedList, totalRecords, totalPages, currentPage);
    }

    /// <summary>
    /// 3.2 ТОП-заказы:
    /// Получить 3 самых дорогих заказа:
    /// OrderByDescending(o => o.Amount).Take(3)
    /// </summary>
    public static List<OrderDisplayDto> GetTop3ExpensiveOrders(
        IEnumerable<Order> orders,
        IEnumerable<Category> categories)
    {
        var categoryMap = categories.ToDictionary(c => c.Id, c => c.Name);

        return orders
            .OrderByDescending(o => o.Amount)
            .Take(3)
            .Select(o => new OrderDisplayDto
            {
                Id = o.Id,
                CustomerName = o.CustomerName,
                CategoryId = o.CategoryId,
                CategoryName = categoryMap.TryGetValue(o.CategoryId, out var catName) ? catName : $"#{o.CategoryId}",
                Amount = o.Amount,
                OrderDate = o.OrderDate
            })
            .ToList();
    }

    /// <summary>
    /// 3.3 Срез списка:
    /// Пропустить первые N устаревших заказов и выбрать оставшиеся:
    /// orders.OrderBy(o => o.OrderDate).Skip(N)
    /// </summary>
    public static List<OrderDisplayDto> SkipOutdatedOrders(
        IEnumerable<Order> orders,
        IEnumerable<Category> categories,
        int skipCount)
    {
        var categoryMap = categories.ToDictionary(c => c.Id, c => c.Name);
        var safeSkip = Math.Max(0, skipCount);

        // Сортировка по дате (старые заказы первыми), затем Skip(N)
        return orders
            .OrderBy(o => o.OrderDate)
            .Skip(safeSkip)
            .Select(o => new OrderDisplayDto
            {
                Id = o.Id,
                CustomerName = o.CustomerName,
                CategoryId = o.CategoryId,
                CategoryName = categoryMap.TryGetValue(o.CategoryId, out var catName) ? catName : $"#{o.CategoryId}",
                Amount = o.Amount,
                OrderDate = o.OrderDate
            })
            .ToList();
    }
}
