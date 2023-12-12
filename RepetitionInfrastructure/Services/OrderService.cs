using RepetitionCore.Dto.Book;
using RepetitionCore.Models;

namespace RepetitionInfrastructure.Services
{
    public class OrderService 
    {
        private readonly RepetitionDbContext _dbContext;
        public OrderService(RepetitionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Order GetOrder(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(i => i.Id == id);

            if (order == null)
            {
                throw new Exception("Item not found");
            }

            return order;
        }
        public async Task<string> CreateOrderAsync(string userId,int basketId)
        {
            var basket = _dbContext.Baskets.FirstOrDefault(i => i.Id == basketId);

            if(basket == null)
            {
                throw new Exception("Basket not found");
            }

            var user = _dbContext.Users.FirstOrDefault(i => i.Id == userId);

            if(user == null)
            {
                throw new Exception("User not found");
            }
        }
        public async Task<Book> UpdateOrderStateAsync(BookDtoUpdate bookDtoUpdate)
        {

        }
        public async Task<Book> UpdateOrderAsync(BookDtoUpdate bookDtoUpdate)
        {
            
        }
        public async Task<bool> DeleteOrderAsync(int id)
        {

        }
    }
}