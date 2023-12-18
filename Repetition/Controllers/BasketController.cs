using Microsoft.AspNetCore.Mvc;
using Repetition.Abstractions;
using RepetitionCore.Dto.Basket;
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
        [HttpGet("AddTo-Basket")]
        public async Task<BasketDto> AddItemToBasketAsync(int basketId, int bookId, int amount)
        {
            return await _basketService.AddItemToBasketAsync(basketId, bookId, amount);
        }
        [HttpPatch("Update-BasketItem")]
        public async Task<string> UpdateBasketItemAsync(int basketId, int basketItemId, int amount)
        {
            return await _basketService.UpdateBasketItemAsync(basketId, basketItemId, amount);
        }
        [HttpGet("Get-Basket")]
        public BasketDto GetBasket(int id)
        {
            return _basketService.GetBasket(id);
        }
        [HttpDelete("Clear-Basket")]
        public async Task<bool> ClearBasketAsync(int id)
        {
            return await _basketService.ClearBasketAsync(id);
        }
    }
}