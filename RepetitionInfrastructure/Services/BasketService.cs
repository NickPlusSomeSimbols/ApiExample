using RepetitionCore.Models;
using RepetitionInfrastructure.ServiceInterfaces;

namespace RepetitionInfrastructure.Services
{
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
        public async Task<int> CreateBasketAsync()
        {
            var basket = new Basket();

            await _dbContext.Baskets.AddAsync(basket);
            await _dbContext.SaveChangesAsync();

            return basket.Id;
        }
        public async Task<bool> DeleteBasketAsync(int id)
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