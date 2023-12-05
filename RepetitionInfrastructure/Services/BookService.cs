﻿using RepetitionCore.Dto.Book;
using RepetitionCore.Models;
using RepetitionInfrastructure.ServiceInterfaces;

namespace RepetitionInfrastructure.Services
{

    // TODO: Add mapping
    public class BookService : IBookService
    {
        private readonly RepetitionDbContext _dbContext;
        public BookService(RepetitionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Book GetBookAsync(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(i => i.Id == id);

            if (book == null)
            {
                throw new Exception("Item not found");
            }

            return book;
        }
        public async Task<Book> CreateBookAsync(BookDto bookDto)
        {
            var randomPublishDate = new DateTime(1943, 12, 01).AddDays(new Random().Next(12000)).ToString("dd/MM/yyyy");

            Book book = new Book
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                PublicationDate = string.IsNullOrEmpty(bookDto.PublicationDate) || bookDto.PublicationDate == "string" ? randomPublishDate : bookDto.PublicationDate,
            };

            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            return book;
        }
        public async Task<Book> UpdateBookAsync(BookDtoUpdate bookDtoUpdate)
        {
            var book = _dbContext.Books.FirstOrDefault(i => i.Id == bookDtoUpdate.Id);

            if (book == null)
            {
                throw new Exception("ItemNotFound");
            }

            book.Title = string.IsNullOrEmpty(bookDtoUpdate.Title) || bookDtoUpdate.Title == "string" ? book.Title : bookDtoUpdate.Title;
            book.Description = string.IsNullOrEmpty(bookDtoUpdate.Description) || bookDtoUpdate.Description == "string" ? book.Description : bookDtoUpdate.Description;
            book.PublicationDate = string.IsNullOrEmpty(bookDtoUpdate.PublicationDate) || bookDtoUpdate.PublicationDate == "string" ? book.PublicationDate : bookDtoUpdate.PublicationDate;

            await _dbContext.SaveChangesAsync();

            return book;
        }
        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(i => i.Id == id);

            if (book == null)
            {
                throw new Exception("Item not found");
            }

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}