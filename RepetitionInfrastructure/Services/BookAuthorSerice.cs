using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepetitionInfrastructure.Services
{
    public class BookAuthorSerice
    {
        private readonly RepetitionDbContext _dbContext;
        public BookAuthorSerice(RepetitionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateBind(int authorId,int bookId)
        {
            var bind = new
            {
                authorId = authorId,
                bookId = bookId
            };

            await _dbContext.AddAsync(bind);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteBind(int Id)
        {
            //var removeBind = _dbContext.AuthorBook.

            //await _dbContext.AddAsync();
            await _dbContext.SaveChangesAsync();
        }
    }
}
