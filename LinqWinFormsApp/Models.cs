using System.ComponentModel;

namespace LinqWinFormsApp;

// C#-модели данных строго по ТЗ:
// Модель категории товара
public record Category(int Id, string Name, double DiscountRate);

// Модель заказа
public record Order(int Id, string CustomerName, int CategoryId, decimal Amount, DateTime OrderDate);

// Projections / DTO для визуализации в DataGridView с удобными названиями столбцов

/// <summary>
/// Результат Задания 1.1: Внутреннее соединение (Join) с расчетом скидок
/// </summary>
public class OrderJoinDiscountDto
{
    [DisplayName("ID заказа")]
    public int OrderId { get; set; }

    [DisplayName("Имя клиента")]
    public string CustomerName { get; set; } = string.Empty;

    [DisplayName("Название категории")]
    public string CategoryName { get; set; } = string.Empty;

    [DisplayName("Сумма заказа")]
    public decimal Amount { get; set; }

    [DisplayName("Размер скидки")]
    public string DiscountPercent => $"{DiscountRate:P0}";

    [DisplayName("Скидка (доля)")]
    public double DiscountRate { get; set; }

    [DisplayName("Сумма со скидкой")]
    public decimal DiscountedAmount { get; set; }

    [DisplayName("Дата заказа")]
    public DateTime OrderDate { get; set; }
}

/// <summary>
/// Результат Задания 1.2: Групповое соединение (GroupJoin) категорий и заказов
/// </summary>
public class CategoryGroupJoinDto
{
    [DisplayName("ID категории")]
    public int CategoryId { get; set; }

    [DisplayName("Название категории")]
    public string CategoryName { get; set; } = string.Empty;

    [DisplayName("Размер базовой скидки")]
    public string DiscountPercent => $"{DiscountRate:P0}";

    [Browsable(false)]
    public double DiscountRate { get; set; }

    [DisplayName("Общее количество заказов")]
    public int OrdersCount { get; set; }

    [DisplayName("Суммарная выручка")]
    public decimal TotalRevenue { get; set; }
}

/// <summary>
/// Результат Задания 2: Группировка (GroupBy) с агрегацией Sum и Average
/// </summary>
public class CategoryGroupStatsDto
{
    [DisplayName("Идентификатор группы (ID категории)")]
    public int CategoryId { get; set; }

    [DisplayName("Название категории")]
    public string CategoryName { get; set; } = string.Empty;

    [DisplayName("Количество заказов")]
    public int OrdersCount { get; set; }

    [DisplayName("Общая сумма выручки (Sum)")]
    public decimal TotalRevenue { get; set; }

    [DisplayName("Средний чек (Average)")]
    public decimal AverageCheck { get; set; }
}

/// <summary>
/// Представление заказа для списков, пагинации и ТОП-3 (Задание 3)
/// </summary>
public class OrderDisplayDto
{
    [DisplayName("ID")]
    public int Id { get; set; }

    [DisplayName("Имя клиента")]
    public string CustomerName { get; set; } = string.Empty;

    [DisplayName("ID Категории")]
    public int CategoryId { get; set; }

    [DisplayName("Название категории")]
    public string CategoryName { get; set; } = string.Empty;

    [DisplayName("Сумма заказа")]
    public decimal Amount { get; set; }

    [DisplayName("Дата заказа")]
    public DateTime OrderDate { get; set; }
}
