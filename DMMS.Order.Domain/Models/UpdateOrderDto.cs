namespace DMMS.Order.Domain.Models;

/// <summary>
/// DTO обновления заказа
/// Используется при изменении заказа через API
/// </summary>
public class UpdateOrderDto
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