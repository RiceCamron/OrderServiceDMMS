using Microsoft.AspNetCore.Mvc;
using DMMS.Order.Application.Interfaces;

namespace DMMS.Order.API.Controllers;

/// <summary>
/// Контроллер управления заказами
/// Позволяет получать, создавать, обновлять, удалять заказы
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    /// <summary>
    /// Конструктор контроллера заказов
    /// </summary>
    /// <param name="orderService"></param>
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Получить список всех заказов
    /// </summary>
    /// <returns>Список заказов</returns>
    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _orderService.GetAllAsync());

    /// <summary>
    /// Получить заказ по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// <returns>Заказ или 404, если не найден</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var order = await _orderService.GetByIdAsync(id);
        return order == null ? NotFound() : Ok(order);
    }

    /// <summary>
    /// Создать новый заказ
    /// </summary>
    /// <param name="order">Данные заказа</param>
    /// <returns>Код 200 при успешном заказе</returns>
    [HttpPost]
    public async Task<IActionResult> Post(Domain.Models.Entities.Order order)
    {
        await _orderService.CreateAsync(order);
        return Ok();
    }

    /// <summary>
    /// Обновить существующий заказ
    /// </summary>
    /// <param name="order">Обновленные данные заказа</param>
    /// <returns>Код 200 при успешном выполнении</returns>
    [HttpPut]
    public async Task<IActionResult> Put(Domain.Models.Entities.Order order)
    {
        await _orderService.UpdateAsync(order);
        return Ok();
    }

    /// <summary>
    /// Удалить заказ по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// <returns>Код 200 при успешном удалении</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _orderService.DeleteAsync(id);
        return Ok();
    }
}