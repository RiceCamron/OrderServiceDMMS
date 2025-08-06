namespace DMMS.Order.Domain.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<Models.Entities.Order>> GetAllAsync(); // Получение всех заказов
    Task<Models.Entities.Order?> GetByIdAsync(Guid id); // Получение заказа по ID
    Task AddAsync(Models.Entities.Order order); // Добавление нового заказа
    Task UpdateAsync(Models.Entities.Order order); // Обновление заказа
    Task DeleteAsync(Models.Entities.Order order); // Удаление заказа
}