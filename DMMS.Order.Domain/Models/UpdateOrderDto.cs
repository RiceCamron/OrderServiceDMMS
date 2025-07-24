namespace DMMS.Order.Domain.Models;

public class UpdateOrderDto
{
    public string CustomerName { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
}