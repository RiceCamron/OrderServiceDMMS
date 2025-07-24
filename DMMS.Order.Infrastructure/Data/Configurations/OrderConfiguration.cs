using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMMS.Order.Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Domain.Models.Entities.Order>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Entities.Order> builder)
    {
        builder.Property(o => o.OrderDate)
            .HasConversion(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
    }
}