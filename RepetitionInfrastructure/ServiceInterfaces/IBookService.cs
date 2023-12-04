using RepetitionCore.Dto.Book;
using RepetitionCore.Models;

namespace RepetitionCore.Services
{
    public interface IBookService
    {
        Task<Book> CreateBookAsync(BookDto bookDto);
        Task<bool> DeleteBookAsync(int id);
        Task<Book> GetBookAsync(int id);
        Task<Book> UpdateBookAsync(BookDtoUpdate bookDtoUpdate);
    }
}