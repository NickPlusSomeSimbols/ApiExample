using RepetitionCore.Dto.Author;
using RepetitionCore.Models;
using RepetitionCore.Services;

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
        public async Task<Author> GetAuthorAsync(int id)
        {
            var author = _dbContext.Authors.FirstOrDefault(i => i.Id == id);

            if (author == null)
            {
                throw new Exception("Item not found");
            }

            return author;
        }
        public async Task<Author> CreateAuthorAsync(AuthorDto authorDto)
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

            return author;
        }
        public async Task<Author> UpdateAuthorAsync(AuthorDtoUpdate authorDtoUpdate)
        {
            Author author = _dbContext.Authors.FirstOrDefault(i => i.Id == authorDtoUpdate.Id);

            if (author == null)
            {
                throw new Exception("ItemNotFound");
            }

            author.Name = string.IsNullOrEmpty(authorDtoUpdate.Name) || author.Name == authorDtoUpdate.Name ? author.Name : authorDtoUpdate.Name;
            author.BirthDate = string.IsNullOrEmpty(authorDtoUpdate.BirthDate) || author.BirthDate == authorDtoUpdate.BirthDate ? author.BirthDate : authorDtoUpdate.BirthDate;
            author.DeathDate = string.IsNullOrEmpty(authorDtoUpdate.DeathDate) || author.DeathDate == authorDtoUpdate.DeathDate ? author.DeathDate : authorDtoUpdate.DeathDate;

            await _dbContext.SaveChangesAsync();

            return author;
        }
        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = _dbContext.Authors.FirstOrDefault(i => i.Id == id);

            if (author == null)
            {
                throw new Exception("Item not found");
            }

            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

