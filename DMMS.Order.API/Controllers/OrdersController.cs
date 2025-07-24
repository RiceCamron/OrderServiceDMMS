using Microsoft.AspNetCore.Mvc;
using DMMS.Order.Application.Interfaces;

namespace DMMS.Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _orderService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var order = await _orderService.GetByIdAsync(id);
        return order == null ? NotFound() : Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Domain.Models.Entities.Order order)
    {
        await _orderService.CreateAsync(order);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(Domain.Models.Entities.Order order)
    {
        await _orderService.UpdateAsync(order);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _orderService.DeleteAsync(id);
        return Ok();
    }
}