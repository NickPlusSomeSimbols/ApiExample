using RepetitionCore.Dto.Author;
using RepetitionCore.Models;

namespace RepetitionCore.Services
{
    public interface IAuthorService
    {
        Task<Author> CreateAuthorAsync(AuthorDto authorDto);
        Task<bool> DeleteAuthorAsync(int id);
        Task<Author> GetAuthorAsync(int id);
        Task<Author> UpdateAuthorAsync(AuthorDtoUpdate authorDtoUpdate);
    }
}