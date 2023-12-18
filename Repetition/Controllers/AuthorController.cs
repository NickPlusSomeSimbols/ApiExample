using Microsoft.AspNetCore.Mvc;
using Repetition.Abstractions;
using RepetitionCore.Dto.Author;
using RepetitionInfrastructure.ServiceInterfaces;

namespace Repetition.Controllers
{
    public class AuthorController : BaseController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet("Get-Author")]
        public AuthorDto AuthorGetAuthorAsync(int id)
        {
            return _authorService.GetAuthor(id);
        }
        [HttpPost("Add-Author")]
        public async Task<AuthorDto> CreateAuthorAsync(AuthorDtoCreate authorDto)
        {
            return await _authorService.CreateAuthorAsync(authorDto);
        }
        [HttpPatch("Update-Author")]
        public async Task<AuthorDto> UpdateAuthorAsync(AuthorDtoUpdate authorDtoUpdate)
        {
            return await _authorService.UpdateAuthorAsync(authorDtoUpdate);
        }
        [HttpDelete("Delete-Author")]
        public async Task<bool> DeleteAuthorAsync(int id)
        {
            return await _authorService.DeleteAuthorAsync(id);
        }
    }
}