using DMMS.Order.Application.Interfaces;
using DMMS.Order.Domain.Interfaces;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repo;

    public OrderService(IOrderRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<DMMS.Order.Domain.Models.Entities.Order>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<DMMS.Order.Domain.Models.Entities.Order?> GetByIdAsync(Guid id)
    {
        var order = await _repo.GetByIdAsync(id);
        if (order == null)
        {
            throw new KeyNotFoundException($"Order with ID {id} not found");
        }
        return order;
    }

    public async Task CreateAsync(DMMS.Order.Domain.Models.Entities.Order order)
    {
        await _repo.AddAsync(order);
    }

    public async Task UpdateAsync(DMMS.Order.Domain.Models.Entities.Order order) => await _repo.UpdateAsync(order);

    public async Task DeleteAsync(Guid id)
    {
        var order = await _repo.GetByIdAsync(id);
        if (order != null)
            await _repo.DeleteAsync(order);
    }
}