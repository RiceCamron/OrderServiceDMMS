namespace DMMS.Order.Domain.Models;

public class AddOrderDto
{
    public string CustomerName { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
}