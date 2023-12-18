using RepetitionCore.Dto.Book;
using RepetitionCore.Models;

namespace RepetitionInfrastructure.ServiceInterfaces
{
    public interface IBookService
    {
        BookDto GetBook(int id);
        Task<BookDto> CreateBookAsync(BookDtoCreate bookDto);
        Task<BookDto> UpdateBookAsync(BookDtoUpdate bookDtoUpdate);
        Task<bool> DeleteBookAsync(int id);
    }
}