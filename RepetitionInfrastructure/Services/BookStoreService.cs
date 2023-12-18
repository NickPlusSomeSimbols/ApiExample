using Mapster;
using RepetitionCore.Dto.Store;
using RepetitionCore.Models;
using RepetitionInfrastructure.ErrorHandling.CustomExceptions;

namespace RepetitionInfrastructure.Services
{
    public class BookStoreService : IBookStoreService
    {
        private readonly RepetitionDbContext _dbContext;
        public BookStoreService(RepetitionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // methods may return both StoreDto and Store depend on access.
        public BookStore GetStore(int id)
        {
            var store = _dbContext.BookStores.FirstOrDefault(x => x.Id == id);

            if (store == null)
            {
                throw new ItemNotFoundException(nameof(store));
            }

            return store;
        }
        public async Task<BookStoreDto> AddStoreAsync(string name)
        {
            BookStore bookStore = new BookStore()
            {
                StoreName = name,
            };

            BookStorage bookStorage = new BookStorage()
            {
                BookStoreId = bookStore.Id,
            };

            await _dbContext.BookStores.AddAsync(bookStore);
            await _dbContext.BookStorages.AddAsync(bookStorage);

            await _dbContext.SaveChangesAsync(); // check if after "save" values are saved and Id are created and accessible

            bookStore.BookStorageId = bookStorage.Id;
            bookStorage.BookStoreId = bookStore.Id;

            await _dbContext.SaveChangesAsync();

            return bookStore.Adapt<BookStoreDto>();
        }
        public string ListStorage(int storeId)
        {
            var storage = _dbContext.BookStorages.Where(i => i.BookStoreId == storeId);

            if (!storage.Any())
            {
                throw new ItemNotFoundException(nameof(storage));
            }

            string report = string.Empty;

            foreach (var storageData in storage)
            {
                report = report + $"Book with Id:{storageData.BookId}, amount:{storageData.BookAmount}, total price:{storageData.Book.Price * storageData.BookAmount}\n";
            }

            return report;
        }
        public async Task<BookStoreDto> UpdateStoreAsync(int id, string newName)
        {
            var store = _dbContext.BookStores.FirstOrDefault(i => i.Id == id);

            if (store == null)
            {
                throw new ItemNotFoundException(nameof(store));
            }

            store.StoreName = newName;

            await _dbContext.SaveChangesAsync();

            return store.Adapt<BookStoreDto>();
        }
        // should not be used mostl of the time
        public bool DeleteStore(int id)
        {
            var store = _dbContext.BookStores.FirstOrDefault(i => i.Id == id);

            if (store == null)
            {
                throw new ItemNotFoundException();
            }

            return true;
        }
    }
}


