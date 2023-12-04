using RepetitionCore.Dto.Author;
using RepetitionCore.Models;

namespace RepetitionInfrastructure.ServiceInterfaces
{
    public interface IAuthorService
    {
        Task<Author> CreateAuthorAsync(AuthorDto authorDto);
        Task<bool> DeleteAuthorAsync(int id);
        Author GetAuthor(int id);
        Task<Author> UpdateAuthorAsync(AuthorDtoUpdate authorDtoUpdate);
    }
}