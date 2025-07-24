namespace DMMS.Order.Contracts.Events;

public class OrderCreatedEvent
{
    public Guid OrderId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}