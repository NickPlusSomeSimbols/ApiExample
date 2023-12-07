using Microsoft.AspNetCore.Mvc;
using Repetition.Abstractions;
using RepetitionCore.Dto.Book;
using RepetitionCore.Models;
using RepetitionInfrastructure.ServiceInterfaces;

namespace Repetition.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("Get-Book")]
        public Book GetBook(int id)
        {
            return _bookService.GetBook(id);
        }
        [HttpPost("Add-Book")]
        public async Task<Book> CreateBookAsync(BookDto bookDto)
        {
            return await _bookService.CreateBookAsync(bookDto);
        }
        [HttpPatch("Update-Book")]
        public async Task<Book> UpdateBookAsync(BookDtoUpdate bookDtoUpdate)
        {
            return await _bookService.UpdateBookAsync(bookDtoUpdate);
        }
        [HttpDelete("Delete-Book")]
        public async Task DeleteBookAsync(int id)
        {
            await _bookService.DeleteBookAsync(id);
        }
    }
}