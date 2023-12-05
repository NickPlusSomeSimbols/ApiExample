using RepetitionCore.Models;

namespace RepetitionInfrastructure.ServiceInterfaces
{
    public interface IBookSoldReportService
    {
        BookSoldReport GetStoreReport(int id);
        Task<BookSoldReport> AddStoreReportAsync(int authorId, int bookId, int amount);
        Task<BookSoldReport> UpdateStoreReportAsync(int Id, int storeId, int amount, int bookId); // this method to continue
        Task<bool> DeleteStoreReportAsync(int id);
    }
}