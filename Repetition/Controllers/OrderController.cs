using Microsoft.AspNetCore.Mvc;
using Repetition.Abstractions;
using RepetitionCore.Models;
using RepetitionInfrastructure.Services;

namespace Repetition.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("Get-Order")]
        public OrderDto GetOrder(int id)
        {
            return _orderService.GetOrder(id);
        }
        [HttpPost("Add-Order")]
        public async Task<OrderDtoCreate> CreateOrderAsync(string userId)
        {
            return await _orderService.CreateOrderAsync(userId);
        }
        [HttpPatch("Update-Order")]
        public string UpdateOrderAsync(OrderDtoUpdateState bookDtoUpdate)
        {
            return _orderService.UpdateOrderState(bookDtoUpdate);
        }
        [HttpDelete("Delete-Order")]
        public bool DeleteOrder(int id)
        {
            return _orderService.DeleteOrder(id);
        }
    }
}
