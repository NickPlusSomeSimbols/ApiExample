using Microsoft.AspNetCore.Mvc;
using Repetition.Abstractions;
using RepetitionCore.Dto.Store;
using RepetitionCore.Models;
using RepetitionInfrastructure.Services;

namespace Repetition.Controllers
{
    public class BookStoreController : BaseController
    {
        private readonly IBookStoreService _bookStoreService;
        public BookStoreController(IBookStoreService bookStoreService)
        {
            _bookStoreService = bookStoreService;
        }
        [HttpGet("Get-Store")]
        public BookStore GetStore(int id)
        {
            return _bookStoreService.GetStore(id);
        }
        [HttpGet("Get-StorageList")]
        public string ListStorage(int storeId)
        {
            return _bookStoreService.ListStorage(storeId);
        }
        [HttpPost("Create-Store")]
        public Task<BookStoreDto> AddStoreAsync(string name)
        {
            return _bookStoreService.AddStoreAsync(name);
        }
        [HttpPatch("Update-Store")]
        public Task<BookStoreDto> UpdateStoreAsync(int id, string newName)
        {
            return _bookStoreService.UpdateStoreAsync(id, newName);
        }
        [HttpDelete("Delete-Store")]
        public bool DeleteStore(int id)
        {
            return _bookStoreService.DeleteStore(id);
        }
    }
}
