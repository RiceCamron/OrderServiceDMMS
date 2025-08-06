namespace DMMS.Order.Domain.Models.Entities;

/// <summary>
/// Сущность заказа хранимая в базе данных
/// </summary>
public class Order
{
    /// <summary>
    /// Уникальный идентификатора заказа
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Имя клиента
    /// </summary>
    public string CustomerName { get; set; }
    /// <summary>
    /// Общая сумма заказа
    /// </summary>
    public decimal TotalAmount { get; set; }
    /// <summary>
    /// Дата оформления заказа
    /// </summary>
    public DateTime OrderDate { get; set; }
    /// <summary>
    /// Наименование заказа
    /// </summary>
    public string ProductName { get; set; }
    /// <summary>
    /// Количество единиц товара
    /// </summary>
    public int Quantity { get; set; }
}