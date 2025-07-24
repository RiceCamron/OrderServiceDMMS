namespace DMMS.Order.Domain.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<Models.Entities.Order>> GetAllAsync();
    Task<Models.Entities.Order?> GetByIdAsync(Guid id);
    Task AddAsync(Models.Entities.Order order);
    Task UpdateAsync(Models.Entities.Order order);
    Task DeleteAsync(Models.Entities.Order order);
}