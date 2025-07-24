using DMMS.Order.Domain.Models.Entities;
namespace DMMS.Order.Application.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<global::DMMS.Order.Domain.Models.Entities.Order>> GetAllAsync();
    Task<global::DMMS.Order.Domain.Models.Entities.Order?> GetByIdAsync(Guid id);
    Task CreateAsync(global::DMMS.Order.Domain.Models.Entities.Order order);
    Task UpdateAsync(global::DMMS.Order.Domain.Models.Entities.Order order);
    Task DeleteAsync(Guid id);
}