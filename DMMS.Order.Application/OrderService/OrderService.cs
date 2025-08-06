using DMMS.Order.Application.Interfaces;
using DMMS.Order.Domain.Interfaces;

/// <summary>
/// Сервис для управления заказами
/// Содержит бизнес-логику и обращается к репозиторию заказов
/// </summary>
public class OrderService : IOrderService
{
    private readonly IOrderRepository _repo;

    /// <summary>
    /// Инициализирует новый экземпляр сервиса заказов
    /// </summary>
    /// <param name="repo">Интерфейс репозитория заказов</param>
    public OrderService(IOrderRepository repo)
    {
        _repo = repo;
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<DMMS.Order.Domain.Models.Entities.Order>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    /// <inheritdoc />
    public async Task<DMMS.Order.Domain.Models.Entities.Order?> GetByIdAsync(Guid id)
    {
        var order = await _repo.GetByIdAsync(id);
        if (order == null)
        {
            throw new KeyNotFoundException($"Order with ID {id} not found");
        }
        return order;
    }

    /// <inheritdoc />
    public async Task CreateAsync(DMMS.Order.Domain.Models.Entities.Order order)
    {
        await _repo.AddAsync(order);
    }

    /// <inheritdoc />
    public async Task UpdateAsync(DMMS.Order.Domain.Models.Entities.Order order) => await _repo.UpdateAsync(order);

    /// <inheritdoc />
    public async Task DeleteAsync(Guid id)
    {
        var order = await _repo.GetByIdAsync(id);
        if (order != null)
            await _repo.DeleteAsync(order);
    }
}