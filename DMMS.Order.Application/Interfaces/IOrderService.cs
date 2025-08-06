using DMMS.Order.Domain.Models.Entities;
namespace DMMS.Order.Application.Interfaces;

/// <summary>
/// Интерфейс сервиса для работы с заказами
/// Определяет методы для получения, создания, обновления, удаления заказов
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Получить список всех заказов
    /// </summary>
    /// <returns>Список заказов</returns>
    Task<IEnumerable<global::DMMS.Order.Domain.Models.Entities.Order>> GetAllAsync();
    
    /// <summary>
    /// Получение заказа по идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Объект заказа или null, если не найден</returns>
    Task<global::DMMS.Order.Domain.Models.Entities.Order?> GetByIdAsync(Guid id);
    
    /// <summary>
    /// Создать новый заказ
    /// </summary>
    /// <param name="order">Обьект заказа для создания</param>
    Task CreateAsync(global::DMMS.Order.Domain.Models.Entities.Order order);
    
    /// <summary>
    /// Обновить существующий заказ
    /// </summary>
    /// <param name="order">Объект заказа с обновлёнными данными</param>
    Task UpdateAsync(global::DMMS.Order.Domain.Models.Entities.Order order);
    
    /// <summary>
    /// Удалить заказ по идентификатору
    /// </summary>
    /// <param name="id">Уникальный идентификатор заказа</param>
    Task DeleteAsync(Guid id);
}