namespace DMMS.Order.Domain.Models;

/// <summary>
/// DTO для добавления нового заказа
/// Используется при создании заказа через API
/// </summary>
public class AddOrderDto
{
    /// <summary>
    /// Имя клиента, оформившего заказ
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
}