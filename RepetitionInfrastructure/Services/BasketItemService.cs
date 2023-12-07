using RepetitionCore.Models;
using RepetitionInfrastructure.ServiceInterfaces;

namespace RepetitionInfrastructure.Services
{
    public class BasketItemService : IBasketItemService
    {
        private readonly RepetitionDbContext _dbContext;
        public BasketItemService(RepetitionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public BasketItem GetBasketItem(int id)
        {
            var basketItem = _dbContext.BasketItems.FirstOrDefault(i => i.Id == id);

            if (basketItem == null)
            {
                throw new Exception("Item not found");
            }

            return basketItem;
        }
        public async Task<BasketItem> CreateItemAsync(int basketId, int bookId, int amount)
        {
            var basket = _dbContext.Baskets.FirstOrDefault(i => i.Id == basketId);

            if (basket == null)
            {
                throw new Exception("Basket not found");
            }

            var book = _dbContext.Books.FirstOrDefault(i => i.Id == basketId);

            if (book == null)
            {
                throw new Exception("Book not found");
            }

            BasketItem item = new BasketItem()
            {
                BasketId = basketId,
                BookId = bookId,
                TotalAmount = amount,
                TotalPrice = amount * book.Price,
            };

            basket.BasketItems.Add(item);
            await _dbContext.SaveChangesAsync();

            return item;
        }
        public async Task<string> UpdateItemAsync(int basketId, int basketItemId, int amount) // if amount = 0 -> delete BasketItem
        {
            var basket = _dbContext.Baskets.FirstOrDefault(i => i.Id == basketId);

            if (basket == null)
            {
                throw new Exception("Basket not found");
            }

            var basketItem = _dbContext.BasketItems.FirstOrDefault(i => i.Id == basketItemId);

            if (basketItem == null)
            {
                throw new Exception("Book not found");
            }

            if (amount == 0)
            {
                _dbContext.BasketItems.Remove(basketItem);
                return $"basketItem with Id = {basketItem.Id} is removed";
            }

            basketItem.TotalAmount = amount;
            basketItem.TotalPrice = amount * basketItem.Book.Price;

            await _dbContext.SaveChangesAsync();

            return @$"BasketItem is updated:
                      {basketItem}";
        }
        public async Task<bool> DeleteItemAsync(int id)
        {
            var basketItem = _dbContext.BasketItems.FirstOrDefault(i => i.Id == id);

            if (basketItem == null)
            {
                throw new Exception("Item not found");
            }

            _dbContext.BasketItems.Remove(basketItem);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
