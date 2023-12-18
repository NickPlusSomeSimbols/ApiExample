using RepetitionCore.Models;

namespace RepetitionInfrastructure.Services
{
    public interface IOrderService
    {
        Task<OrderDtoCreate> CreateOrderAsync(string userId, int basketId);
        Task<bool> DeleteOrderAsync(int id);
        OrderDto GetOrder(int id);
        Task<OrderDto> UpdateOrderAsync(OrderDtoUpdate orderDtoUpdate);
    }
}