using RepetitionCore.Models;

namespace RepetitionInfrastructure.Services
{
    public interface IBasketService
    {
        Task<bool> DeleteBookAsync(int id);
        Basket GetBasket(int id);
    }
}