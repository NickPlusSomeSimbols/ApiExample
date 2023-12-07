using Microsoft.AspNetCore.Mvc;
using Repetition.Abstractions;
using RepetitionCore.Models;
using RepetitionInfrastructure.Services;

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
        [HttpDelete("Delete-Book")]
        public async Task DeleteBookAsync(int id)
        {
            await _basketService.DeleteBookAsync(id);
        }
    }
}