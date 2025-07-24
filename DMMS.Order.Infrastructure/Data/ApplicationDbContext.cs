using DMMS.Order.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DMMS.Order.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<Domain.Models.Entities.Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration<Domain.Models.Entities.Order>(new OrderConfiguration());
    }
}