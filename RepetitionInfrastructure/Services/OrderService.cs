using RepetitionCore.Models.Enums;
using RepetitionCore.Models;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace RepetitionInfrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly RepetitionDbContext _dbContext;
        public OrderService(RepetitionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public OrderDto GetOrder(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(i => i.Id == id);

            if (order == null)
            {
                throw new Exception("Item not found");
            }

            return order.Adapt<OrderDto>();
        }
        public async Task<OrderDtoCreate> CreateOrderAsync(string userId, int basketId)
        {
            var basket = _dbContext.Baskets.FirstOrDefault(i => i.Id == basketId);

            if (basket == null)
            {
                throw new Exception("Basket is not found");
            }

            var user = _dbContext.Users.FirstOrDefault(i => i.Id == userId);

            if (user == null)
            {
                throw new Exception("User is not found");
            }

            var basketItems = _dbContext.BasketItems.Where(i => i.BasketId == basketId);

            if (!basketItems.Any())
            {
                throw new Exception("Unable to create empty oreder");
            }

            var order = new Order()
            {
                CreationDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                Price = basketItems.Sum(i => i.TotalPrice),
                Items = basketItems.Adapt<List<OrderItem>>(),
                State = OrderState.Prepearing,
            };

            return null; //!!!
        }
        /*public async Task<OrderDtoUpdateState> UpdateOrderStateAsync(OrderDtoUpdateState bookDtoUpdate)
        {

        }*/
        public async Task<OrderDto> UpdateOrderAsync(OrderDtoUpdate orderDtoUpdate)
        {
            Order? order = _dbContext.Orders.Include(i => i.Items).FirstOrDefault(i => i.Id == orderDtoUpdate.OrderId);

            if (order == null)
            {
                throw new Exception("No such order found");
            }

            if (order.State != OrderState.InQueue)
            {
                throw new InvalidOperationException("Order already is on the way");
            }

            // Implement Counting in storage

            OrderItem? orderItem = order.Items.FirstOrDefault(i => i.Id == orderDtoUpdate.OrderItemid);
            orderItem.Amount = orderDtoUpdate.Amount;

            return null; //!!!!!
        }
        public async Task<bool> DeleteOrderAsync(int id)
        {
            return false; //!!!
        }
    }
}