using DMMS.Order.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DMMS.Order.Infrastructure.Data;

/// <summary>
/// Контекст базы данных приложения
/// Отвечает за взаимодействие с таблицами и настройку моделей
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Конструктор, инициализирующий контекст с переданными опциями
    /// </summary>
    /// <param name="options">Параметры конфигурации контекста</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    /// <summary>
    /// Таблица заказов (Orders)
    /// </summary>
    public DbSet<Domain.Models.Entities.Order> Orders { get; set; }

    /// <summary>
    /// Настройка моделей при создании схемы БД
    /// Подключает конфигурации сущностей
    /// </summary>
    /// <param name="modelBuilder">Построитель модели EF</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Применяем конфигурацию OrderConfiguration к сущности Order
        modelBuilder.ApplyConfiguration<Domain.Models.Entities.Order>(new OrderConfiguration());
    }
}