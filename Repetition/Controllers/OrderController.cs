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
        [HttpGet("Get-Book")]
        public OrderDto GetOrder(int id)
        {
            return _orderService.GetOrder(id);
        }
        [HttpPost("Add-Book")]
        public async Task<OrderDtoCreate> CreateOrderAsync(string userId, int basketId) // to rething UserId/BasketId
        {
            return await _orderService.CreateOrderAsync(userId, basketId);
        }
        [HttpPatch("Update-Book")]
        public async Task<OrderDto> UpdateOrderAsync(OrderDtoUpdate bookDtoUpdate)
        {
            return await _orderService.UpdateOrderAsync(bookDtoUpdate);
        }
        [HttpDelete("Delete-Book")]
        public async Task<bool> DeleteOrder(int id)
        {
            return await _orderService.DeleteOrderAsync(id);
        }
    }
}
