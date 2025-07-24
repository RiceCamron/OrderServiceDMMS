using DMMS.Order.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DMMS.Order.Infrastructure.Data;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Domain.Models.Entities.Order>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Domain.Models.Entities.Order?> GetByIdAsync(Guid id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task AddAsync(Domain.Models.Entities.Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Domain.Models.Entities.Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Domain.Models.Entities.Order order)
    {
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }
}