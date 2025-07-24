namespace DMMS.Order.Domain.Models.Entities;

public class Order
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}