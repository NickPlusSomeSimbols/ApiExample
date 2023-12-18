using RepetitionCore.Dto.Author;
using RepetitionCore.Models;

namespace RepetitionInfrastructure.ServiceInterfaces
{
    public interface IAuthorService
    {
        AuthorDto GetAuthor(int id);
        Task<AuthorDto> CreateAuthorAsync(AuthorDtoCreate authorDto);
        Task<AuthorDto> UpdateAuthorAsync(AuthorDtoUpdate authorDtoUpdate);
        Task<bool> DeleteAuthorAsync(int id);
    }
}