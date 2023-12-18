using Repetition.Abstractions;
using Microsoft.AspNetCore.Mvc;
using RepetitionInfrastructure.ServiceInterfaces;

namespace Repetition.Controllers
{
    public class AuthorBookController : BaseController
    {
        private readonly IAuthorBookService _authorBookService;
        public AuthorBookController(IAuthorBookService authorBookService)
        {
            _authorBookService = authorBookService;
        }
        [HttpGet("Get-All-Binds")]
        public string AuthorGetAuthorAsync()
        {
            return _authorBookService.GetAllBinds();
        }
        [HttpPost("Add-Bind")]
        public async Task<string> BindAuthorBookAsync(int authorId, int bookId)
        {
            return await _authorBookService.AddBindAsync(authorId, bookId);
        }
        [HttpPatch("Update-Bind")]
        public async Task<string> UpdateBookAuthorBindAsync(int Id, int authorId, int bookId)
        {
            return await _authorBookService.UpdateBookToAuthorAsync(Id, authorId, bookId);
        }
        [HttpDelete("Delete-Bind")]
        public async Task<bool> DeleteBookAuthorBindAsync(int id)
        {
            return await _authorBookService.DeleteBindAsync(id);
        }
    }
}