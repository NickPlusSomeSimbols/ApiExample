using Microsoft.AspNetCore.Mvc;
using Repetition.Abstractions;
using RepetitionCore.Models;
using RepetitionInfrastructure.ServiceInterfaces;

namespace Repetition.Controllers
{
    public class BasketController : BaseController
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet("Get-Book")]
        public Basket GetBasket(int id)
        {
            return _basketService.GetBasket(id);
        }
        [HttpGet("Create-Book")]
        public async Task<int> CreateBasketAsync()
        {
            return await _basketService.CreateBasketAsync();
        }
        [HttpDelete("Delete-Book")]
        public async Task<bool> DeleteBookAsync(int id)
        {
            return await _basketService.DeleteBasketAsync(id);
        }
    }
}