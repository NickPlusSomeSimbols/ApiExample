using Mapster;
using RepetitionCore.Dto.Basket;
using RepetitionCore.Dto.BasketItem;
using RepetitionCore.Models;
using RepetitionInfrastructure.ErrorHandling;
using RepetitionInfrastructure.ErrorHandling.CustomExceptions;
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
        public BasketDto GetBasket(int id)
        {
            var basket = _dbContext.Baskets.FirstOrDefault(i => i.Id == id);

            if (basket == null)
            {
                throw new Exception("Item not found");
            }

            return basket.Adapt<BasketDto>(); // Done
        }
        public BasketItemDto GetBasketItem(int id)
        {
            var basketItem = _dbContext.BasketItems.FirstOrDefault(i => i.Id == id);

            if (basketItem == null)
            {
                throw new ItemNotFoundException(nameof(basketItem));
            }

            return basketItem.Adapt<BasketItemDto>(); // Done
        }
        public async Task<BasketDto> AddItemToBasketAsync(int basketId, int bookId, int amount)
        {
            var basket = _dbContext.Baskets.FirstOrDefault(i => i.Id == basketId);

            if (basket == null)
            {
                throw new ItemNotFoundException(nameof(basket));
            }

            var book = _dbContext.Books.FirstOrDefault(i => i.Id == basketId);

            if (book == null)
            {
                throw new ItemNotFoundException(nameof(book));
            }

            var store = _dbContext.BookStores.FirstOrDefault(); // CONSIDERED TO HAVE ONLY ONE STORE

            if (store == null)
            {
                throw new ItemNotFoundException(nameof(store));
            }

            var storage = _dbContext.BookStorages.FirstOrDefault(i => i.BookStoreId == store.Id);

            if (storage == null)
            {
                throw new ItemNotFoundException(nameof(storage));
            }

            if (storage.BookAmount < amount)
            {
                throw new Exception("Not enough book of this type in storage");
            }

            BasketItem item = new BasketItem()
            {
                BasketId = basketId,
                BookId = bookId,
                Amount = amount,
                TotalPrice = amount * book.Price,
            };

            storage.BookAmount -= amount;
            basket.BasketItems.Add(item);

            await _dbContext.SaveChangesAsync();

            return basket.Adapt<BasketDto>(); // Done
        }
        public async Task<string> UpdateBasketItemAsync(int basketId, int basketItemId, int amount) // if amount = 0 -> delete BasketItem
        {
            var basket = _dbContext.Baskets.FirstOrDefault(i => i.Id == basketId);

            if (basket == null)
            {
                throw new ItemNotFoundException(nameof(basket));
            }

            var basketItem = _dbContext.BasketItems.FirstOrDefault(i => i.Id == basketItemId);

            if (basketItem == null)
            {
                throw new ItemNotFoundException(nameof(basketItem));
            }

            var store = _dbContext.BookStores.FirstOrDefault(); // CONSIDERED TO HAVE ONLY ONE STORE

            if (store == null)
            {
                throw new ItemNotFoundException(nameof(store));
            }

            var storage = _dbContext.BookStorages.FirstOrDefault(i => i.BookStoreId == store.Id);

            if (storage == null)
            {
                throw new ItemNotFoundException(nameof(storage));
            }

            if (amount == 0)
            {
                storage.BookAmount += basketItem.Amount;

                _dbContext.BasketItems.Remove(basketItem);
                return $"basketItem with Id = {basketItem.Id} is removed";
            }

            storage.BookAmount += (basketItem.Amount - amount);

            basketItem.Amount = amount;
            basketItem.TotalPrice = amount * basketItem.Book.Price;

            await _dbContext.SaveChangesAsync();

            return @$"BasketItem is updated:
                      {basketItem.Adapt<BasketItemDto>()}";
        } //Done

        public async Task<bool> ClearBasketAsync(int basketId)
        {
            var basket = _dbContext.Baskets.FirstOrDefault(i => i.Id == basketId);

            if (basket == null)
            {
                throw new ItemNotFoundException(nameof(basket));
            }

            basket.BasketItems.Clear();
            await _dbContext.SaveChangesAsync();

            return true;
        } // Done
    }

}