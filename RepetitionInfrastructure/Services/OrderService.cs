using Mapster;
using Microsoft.EntityFrameworkCore;
using RepetitionCore.Models;
using RepetitionCore.Models.Enums;
using RepetitionInfrastructure.ErrorHandling.CustomExceptions;

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
        public async Task<OrderDtoCreate> CreateOrderAsync(string userName)
        {
            var user = _dbContext.Users.FirstOrDefault(i => i.UserName == userName);

            if (user == null)
            {
                throw new Exception("User is not found");
            }

            var basket = _dbContext.Baskets.FirstOrDefault(i => i.ApplicationUserId == user.Id);

            if (basket == null)
            {
                throw new Exception("Unexpeted error, no basket binded to user found");
            }

            var basketItems = _dbContext.BasketItems.Where(i => i.BasketId == basket.Id);

            if (!basketItems.Any())
            {
                throw new Exception("Unable to create an empty oreder");
            }

            var order = new Order()
            {
                CreationDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                Price = basketItems.Sum(i => i.TotalPrice),
                Items = basketItems.Adapt<List<OrderItem>>(),
                State = OrderState.Prepearing,
            };

            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            return order.Adapt<OrderDtoCreate>();

        }
        public string UpdateOrderState(OrderDtoUpdateState bookDtoUpdate)
        {
            var order = _dbContext.Orders.FirstOrDefault(i => i.Id == bookDtoUpdate.OrderId);

            if (order == null)
            {
                throw new ItemNotFoundException();
            }

            var oldState = order.State;

            OrderState state = new() { };

            OrderState[] Arr = (OrderState[])Enum.GetValues(state.GetType());
            int j = Array.IndexOf<OrderState>(Arr, state) + 1;
            order.State = (Arr.Length == j) ? Arr[0] : Arr[j];

            return $"State is changed from {oldState} to {order.State}";
        }
        //public orderdto updateorder(orderdtoupdate orderdtoupdate)
        //{
        //    order? order = _dbcontext.orders.include(i => i.items).firstordefault(i => i.id == orderdtoupdate.orderid);

        //    if (order == null)
        //    {
        //        throw new exception("no such order found");
        //    }

        //    if (order.state != orderstate.inqueue)
        //    {
        //        throw new invalidoperationexception("order already is on the way");
        //    }

        // Count in storage

        //    orderitem? orderitem = order.items.firstordefault(i => i.id == orderdtoupdate.orderitemid);
        //    orderitem.amount = orderdtoupdate.amount;

        //    return null; //!!!!!
        //}
        public bool DeleteOrder(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(i => i.Id == id);

            if (order == null)
            {
                throw new ItemNotFoundException("No such order");
            }

            _dbContext.Orders.Remove(order);
            return true;
        }
    }
}