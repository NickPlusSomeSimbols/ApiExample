using RepetitionCore.Abstractions;

namespace RepetitionCore.Models
{
    public class BookStore : BaseEntity
    {
        public string StoreName { get; set; }
        public string BookStorageId { get; set; }
        public BookStorage BookStorage { get; set; }
    }
}
