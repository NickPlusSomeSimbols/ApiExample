using RepetitionCore.Models;
using RepetitionInfrastructure.ServiceInterfaces;

namespace RepetitionInfrastructure.Services
{
    public class AuthorBookService : IAuthorBookService
    {
        private readonly RepetitionDbContext _dbContext;
        public AuthorBookService(RepetitionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string GetAllBinds()
        {
            var binds = _dbContext.AuthorBooks.ToList();

            string result = string.Empty;

            foreach (var bind in binds)
            {
                result = result + $"BookId: {bind.BookId} - AuthorId: {bind.AuthorId}" + System.Environment.NewLine;
            }

            return result;
        }

        public async Task<string> AddBookToAuthorAsync(int authorId, int bookId)
        {
            var book = _dbContext.Books.FirstOrDefault(i => i.Id == bookId);

            if (book == null)
            {
                throw new Exception("Item not Found");
            }

            var author = _dbContext.Authors.FirstOrDefault(i => i.Id == authorId);

            if (author == null)
            {
                throw new Exception("Item not Found");
            }

            var authorBook = new AuthorBook
            {
                AuthorId = authorId,
                BookId = bookId
            };

            await _dbContext.AuthorBooks.AddAsync(authorBook);
            await _dbContext.SaveChangesAsync();

            return $"Binded: BookId-{bookId} to AuthorId-{authorId}";
        }

        public async Task<string> UpdateBookToAuthorAsync(int Id, int authorId, int bookId)
        {
            var bind = _dbContext.AuthorBooks.FirstOrDefault(i => i.Id == Id);

            if (bind == null)
            {
                throw new Exception("Item not Found");
            }

            var book = _dbContext.Books.FirstOrDefault(i => i.Id == bookId);

            if (book == null)
            {
                throw new Exception("Item not Found");
            }

            var author = _dbContext.Authors.FirstOrDefault(i => i.Id == authorId);

            if (author == null)
            {
                throw new Exception("Item not Found");
            }

            var oldBindA = bind.AuthorId;
            var oldBindB = bind.BookId;

            bind.AuthorId = authorId;
            bind.BookId = bookId;

            await _dbContext.SaveChangesAsync();

            return "Binded changed: " + System.Environment.NewLine +
                $"From: BookId-{bookId} to AuthorId-{authorId}" + System.Environment.NewLine +
                $"To: BookId-{oldBindB} to AuthorId-{oldBindA}";
        }

        public Task<bool> DeleteBookAuthorBindAsync(int id)
        {
            var bind = _dbContext.AuthorBooks.FirstOrDefault(i => i.Id == id);

            if (bind == null)
            {
                return Task.FromResult(false);
            }

            _dbContext.AuthorBooks.Remove(bind);

            return Task.FromResult(true);
        }
    }
}
