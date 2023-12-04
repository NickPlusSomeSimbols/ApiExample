using RepetitionCore.Dto.Book;
using RepetitionCore.Models;

namespace RepetitionInfrastructure.ServiceInterfaces
{
    public interface IBookService
    {
        Task<Book> CreateBookAsync(BookDto bookDto);
        Task<bool> DeleteBookAsync(int id);
        Book GetBookAsync(int id);
        Task<Book> UpdateBookAsync(BookDtoUpdate bookDtoUpdate);
    }
}