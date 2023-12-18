namespace RepetitionInfrastructure.ServiceInterfaces
{
    public interface IAuthorBookService
    {
        Task<string> AddBindAsync(int authorId, int bookId);
        Task<bool> DeleteBindAsync(int id);
        string GetAllBinds();
        Task<string> UpdateBookToAuthorAsync(int Id, int authorId, int bookId);
    }
}