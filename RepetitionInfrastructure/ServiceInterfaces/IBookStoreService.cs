using RepetitionCore.Dto.Store;
using RepetitionCore.Models;

namespace RepetitionInfrastructure.Services
{
    public interface IBookStoreService
    {
        BookStore GetStore(int id);
        Task<BookStoreDto> AddStoreAsync(string name);
        Task<string> SetStorageStock(string storeName, StorageStockDto storageStockDto);
        string ListStorage(int storeId);
        Task<BookStoreDto> UpdateStoreAsync(int id, string newName);
        Task <bool> DeleteStoreAsync(int id);
    }
}