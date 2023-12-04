using RepetitionCore.Abstractions;

namespace RepetitionCore.Models
{
    public class BookStore : BaseEntity
    {
        public string StoreName { get; set; }
        public int BookStorageId { get; set; }
        public BookStorage BookStorage { get; set; }
    }
}
