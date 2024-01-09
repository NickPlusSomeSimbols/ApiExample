using Mapster;
using RepetitionCore.Dto.Store;
using RepetitionCore.Models;
using RepetitionInfrastructure.ErrorHandling.CustomExceptions;
using Microsoft.EntityFrameworkCore;

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

            await _dbContext.BookStores.AddAsync(bookStore);
            await _dbContext.SaveChangesAsync();

            return bookStore.Adapt<BookStoreDto>();
        }
        public string ListStorage(int storeId)
        {
            var storage = _dbContext.BookStorages.Where(i => i.BookStoreId == storeId).ToList();

            if (!storage.Any())
            {
                string report = string.Empty;

                foreach (var storageData in storage)
                {
                    report += $"Book with Id:{storageData.BookId}, amount:{storageData.BookAmount}, total price:{storageData.Book.Price * storageData.BookAmount}\n";
                }

                return report;
            }
            return "Storage is empty";
        }
        public async Task<string> SetStorageStock(string storeName, StorageStockDto storageStockDto)
        {
            var store = _dbContext.BookStores.FirstOrDefault(i => i.StoreName == storeName);

            if (store == null)
            {
                throw new ItemNotFoundException(nameof(store));
            }

            if (_dbContext.BookStorages.FirstOrDefault(i => i.BookId == storageStockDto.BookId) != null)
            {
                throw new Exception("This item already exists");
            }

            var storageItem = new BookStorage
            {
                Book = _dbContext.Books.FirstOrDefault(i => i.Id == storageStockDto.BookId),
                BookId = storageStockDto.BookId,
                BookAmount = storageStockDto.BookAmount,
                BookStoreId = store.Id,
                BookStore = store,
            };

            await _dbContext.AddAsync(storageItem);
            await _dbContext.SaveChangesAsync();

            return ListStorage(store.Id);
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
        public async Task<bool> DeleteStoreAsync(int id)
        {
            var store = _dbContext.BookStores.FirstOrDefault(i => i.Id == id);

            if (store == null)
            {
                throw new ItemNotFoundException(nameof(store));
            }

            var storage = _dbContext.BookStorages.FirstOrDefault(i => i.BookStoreId == store.Id);

            if (storage == null)
            {
                throw new ItemNotFoundException("Unexpected error, storage is not found");
            }

            _dbContext.BookStorages.Remove(storage);
            _dbContext.BookStores.Remove(store);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}


