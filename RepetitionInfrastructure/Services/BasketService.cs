using RepetitionCore.Dto.Book;
using RepetitionCore.Models;
using RepetitionInfrastructure.ServiceInterfaces;

namespace RepetitionInfrastructure.Services
{

    // TODO: Add mapping
    public class BasketService : IBasketService
    {
        private readonly RepetitionDbContext _dbContext;
        public BasketService(RepetitionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Basket GetBasket(int id)
        {
            var basket = _dbContext.Baskets.FirstOrDefault(i => i.Id == id);

            if (basket == null)
            {
                throw new Exception("Item not found");
            }

            return basket;
        }
        public async Task<bool> DeleteBookAsync(int id)
        {
            var basket = _dbContext.Baskets.FirstOrDefault(i => i.Id == id);

            if (basket == null)
            {
                throw new Exception("Item not found");
            }

            _dbContext.Baskets.Remove(basket);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
