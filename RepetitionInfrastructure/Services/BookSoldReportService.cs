using RepetitionCore.Models;
using RepetitionInfrastructure.ServiceInterfaces;

namespace RepetitionInfrastructure.Services
{
    public class BookSoldReportService : IBookSoldReportService
    {
        private readonly RepetitionDbContext _dbContext;
        public BookSoldReportService(RepetitionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public BookSoldReport GetStoreReport(int id)
        {
            var report = _dbContext.BookSoldReports.FirstOrDefault(i => i.Id == id);
            
            if (report == null)
            {
                throw new Exception("No item found");
            }

            return report;
        }
        public async Task<BookSoldReport> AddStoreReportAsync(int storeId, int bookId, int amount)
        {
            var store = _dbContext.BookStores.FirstOrDefault(i => i.Id == storeId);

            if(store == null)
            {
                throw new Exception("No such store found");
            }

            var book = _dbContext.Books.FirstOrDefault(i => i.Id == bookId);

            if (book == null)
            {
                throw new Exception("No such book found");
            }

            BookSoldReport report = new BookSoldReport
            {
                BookId = bookId,
                BookStoreId = storeId,
                PurchaseAmount = amount,
                Income = book.Price * amount,
                PuchaseDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
            };

            await _dbContext.BookSoldReports.AddAsync(report);
            await _dbContext.SaveChangesAsync();

            return report;
        }

        public async Task<BookSoldReport> UpdateStoreReportAsync(int Id, int storeId, int amount, int bookId)
        {
            var report = _dbContext.BookSoldReports.FirstOrDefault(i => i.Id == Id);

            if (report == null)
            {
                throw new Exception("No such report found");
            }

            var book = _dbContext.Books.FirstOrDefault(i => i.Id == bookId);

            if (book == null)
            {
                throw new Exception("No such book found");
            }

            report.BookId = bookId;
            report.BookStoreId = storeId;
            report.PurchaseAmount = amount;
            report.Income = book.Price * amount;
            report.PuchaseDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            await _dbContext.SaveChangesAsync();  

            return report;
        }
        public async Task<bool> DeleteStoreReportAsync(int id)
        {
            var report = _dbContext.BookSoldReports.FirstOrDefault(i => i.Id == id);

            if (report == null)
            {
                throw new Exception("No such report found");
            }

            _dbContext.BookSoldReports.Remove(report);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

/*private readonly IBookSoldReportService _bookSoldReportService;
public BookSoldReportService(IBookSoldReportService bookSoldReportService)
{
    _bookSoldReportService = bookSoldReportService;
}*/
