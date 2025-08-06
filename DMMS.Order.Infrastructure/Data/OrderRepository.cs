using DMMS.Order.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DMMS.Order.Infrastructure.Data;

/// <summary>
/// Репощиторий для работы с сущностью Order
/// Реализует доступ к базе данных через EF Core
/// </summary>
public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Инициализирует новый экземляр OrderRepository
    /// </summary>
    /// <param name="context">Контекст базы данных</param>
    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Domain.Models.Entities.Order>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Domain.Models.Entities.Order?> GetByIdAsync(Guid id)
    {
        return await _context.Orders.FindAsync(id);
    }

    /// <inheritdoc />
    public async Task AddAsync(Domain.Models.Entities.Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task UpdateAsync(Domain.Models.Entities.Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Domain.Models.Entities.Order order)
    {
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }
}