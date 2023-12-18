using RepetitionCore.Dto.Store;
using RepetitionCore.Models;

namespace RepetitionInfrastructure.Services
{
    public interface IBookStoreService
    {
        Task<BookStoreDto> AddStoreAsync(string name);
        bool DeleteStore(int id);
        BookStore GetStore(int id);
        string ListStorage(int storeId);
        Task<BookStoreDto> UpdateStoreAsync(int id, string newName);
    }
}