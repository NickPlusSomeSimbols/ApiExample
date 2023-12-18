using RepetitionCore.Dto.Basket;
using RepetitionCore.Models;

namespace RepetitionInfrastructure.ServiceInterfaces
{
    public interface IBasketService
    {
        Task<BasketDto> AddItemToBasketAsync(int basketId, int bookId, int amount);
        Task<string> UpdateBasketItemAsync(int basketId, int basketItemId, int amount);
        Task<bool> ClearBasketAsync(int basketId);
        BasketDto GetBasket(int id);
    }
}