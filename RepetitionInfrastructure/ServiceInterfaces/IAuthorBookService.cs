namespace RepetitionInfrastructure.ServiceInterfaces
{
    public interface IAuthorBookService
    {
        Task<string> AddBookToAuthorAsync(int authorId, int bookId);
        Task<bool> DeleteBookAuthorBindAsync(int id);
        string GetAllBinds();
        Task<string> UpdateBookToAuthorAsync(int Id, int authorId, int bookId);
    }
}