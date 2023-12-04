using Repetition.Abstractions;
using RepetitionCore.Models;
using RepetitionCore.Dto.Author;
using Microsoft.AspNetCore.Mvc;
using RepetitionInfrastructure.Services;
using RepetitionCore.Services;

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
        public async Task<Author> GetAuthorAsync(int id)
        {
            return await _authorService.GetAuthorAsync(id);
        }
        [HttpPost("Add-Author")]
        public async Task<Author> CreateAuthorAsync(AuthorDto authorDto)
        {
            return await _authorService.CreateAuthorAsync(authorDto);
        }
        [HttpPatch("Update-Author")]
        public async Task<Author> UpdateAuthorAsync(AuthorDtoUpdate authorDtoUpdate)
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