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
        public BookDto GetBook(int id)
        {
            return _bookService.GetBook(id);
        }
        [HttpPost("Add-Book")]
        public async Task<BookDto> CreateBookAsync(BookDtoCreate bookDto)
        {
            return await _bookService.CreateBookAsync(bookDto);
        }
        [HttpPatch("Update-Book")]
        public async Task<BookDto> UpdateBookAsync(BookDtoUpdate bookDtoUpdate)
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