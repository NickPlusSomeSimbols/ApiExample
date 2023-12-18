using Mapster;
using Microsoft.EntityFrameworkCore;
using RepetitionCore.Dto.Author;
using RepetitionCore.Models;
using RepetitionInfrastructure.ErrorHandling.CustomExceptions;
using RepetitionInfrastructure.ServiceInterfaces;

namespace RepetitionInfrastructure.Services
{
    // TODO: Add mapping
    public class AuthorService : IAuthorService
    {
        private readonly RepetitionDbContext _dbContext;
        public AuthorService(RepetitionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public AuthorDto GetAuthor(int id)
        {
            var author = _dbContext.Authors.FirstOrDefault(i => i.Id == id);

            if (author == null)
            {
                throw new ItemNotFoundException(nameof(author));
            }

            return author.Adapt<AuthorDto>();
        }
        public async Task<AuthorDto> CreateAuthorAsync(AuthorDtoCreate authorDto)
        {
            var randomBirthDate = new DateTime(1923, 12, 01).AddDays(new Random().Next(20000)).ToString("dd/MM/yyyy");
            var randomDeathDate = DateTime.Now.AddDays(-new Random().Next(10000)).ToString("dd/MM/yyyy");

            Author author = new Author
            {
                Name = authorDto.Name,
                BirthDate = string.IsNullOrEmpty(authorDto.BirthDate) || authorDto.BirthDate == "string" ? randomBirthDate : authorDto.BirthDate,
                DeathDate = string.IsNullOrEmpty(authorDto.BirthDate) || authorDto.DeathDate == "string" ? randomDeathDate : authorDto.DeathDate,
            };

            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();

            return author.Adapt<AuthorDto>();
        }
        public async Task<AuthorDto> UpdateAuthorAsync(AuthorDtoUpdate authorDtoUpdate)
        {
            var author = _dbContext.Authors.FirstOrDefault(i => i.Id == authorDtoUpdate.Id);

            if (author == null)
            {
                throw new ItemNotFoundException(nameof(author));
            }

            author.Name = string.IsNullOrEmpty(authorDtoUpdate.Name) || author.Name == authorDtoUpdate.Name ? author.Name : authorDtoUpdate.Name;
            author.BirthDate = string.IsNullOrEmpty(authorDtoUpdate.BirthDate) || authorDtoUpdate.BirthDate == "string" ? author.BirthDate : authorDtoUpdate.BirthDate;
            author.DeathDate = string.IsNullOrEmpty(authorDtoUpdate.DeathDate) || authorDtoUpdate.DeathDate == "string" ? author.DeathDate : authorDtoUpdate.DeathDate;

            await _dbContext.SaveChangesAsync();

            return author.Adapt<AuthorDto>();
        }
        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = _dbContext.Authors.FirstOrDefault(i => i.Id == id);

            if (author == null)
            {
                throw new ItemNotFoundException(nameof(author));
            }

            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

