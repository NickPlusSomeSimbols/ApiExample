using Mapster;
using RepetitionCore.Dto.Basket;
using RepetitionCore.Models;

namespace RepetitionCore
{
    public class MappingConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<BasketItem, OrderItem>.NewConfig()
                .Map(d => d.Price, s => s.TotalPrice)
                .Map(d => d.Amount, s => s.Amount)
                .Map(d => d.BookId, s => s.BookId)
                .Ignore(d => d.Order)
                .Ignore(d => d.OrderId);
        }
    }
}
