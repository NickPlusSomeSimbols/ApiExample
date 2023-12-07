using RepetitionCore.Models;

namespace RepetitionInfrastructure.ServiceInterfaces
{
    public interface IBasketItemService
    {
        Task<BasketItem> CreateItemAsync(int basketId, int bookId, int amount);
        Task<bool> DeleteItemAsync(int id);
        BasketItem GetBasketItem(int id);
        Task<string> UpdateItemAsync(int basketId, int basketItemId, int amount);
    }
}