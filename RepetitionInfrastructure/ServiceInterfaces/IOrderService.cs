using RepetitionCore.Models;

namespace RepetitionInfrastructure.Services
{
    public interface IOrderService
    {
        OrderDto GetOrder(int id);
        Task<OrderDtoCreate> CreateOrderAsync(string userName);
        string UpdateOrderState(OrderDtoUpdateState bookDtoUpdate);
        bool DeleteOrder(int id);
    }
}