using RepetitionCore.Models;

namespace RepetitionInfrastructure.ServiceInterfaces
{
    public interface IBasketService
    {
        Task<bool> DeleteBasketAsync(int id);
        Basket GetBasket(int id);
        Task<int> CreateBasketAsync();
    }
}