using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMMS.Order.Infrastructure.Data.Configurations;

/// <summary>
/// Конфигурация сущности Order для EF Core
/// Устанавливает правила хранения даты заказа в формате UTC
/// </summary>
public class OrderConfiguration : IEntityTypeConfiguration<Domain.Models.Entities.Order>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Entities.Order> builder)
    {
        // Преобразование даты заказа в UTC при сохранении и чтении из БД
        builder.Property(o => o.OrderDate)
            .HasConversion(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
    }
}