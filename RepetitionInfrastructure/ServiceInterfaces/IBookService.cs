using RepetitionCore.Dto.Book;
using RepetitionCore.Models;

namespace RepetitionInfrastructure.ServiceInterfaces
{
    public interface IBookService
    {
        Book GetBook(int id);
        Task<Book> CreateBookAsync(BookDto bookDto);
        Task<Book> UpdateBookAsync(BookDtoUpdate bookDtoUpdate);
        Task<bool> DeleteBookAsync(int id);
    }
}