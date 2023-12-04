using RepetitionCore.Abstractions;

namespace RepetitionCore.Models
{
    public class BookStorage : BaseEntity
    {
        public int BookAmount { get; set; }
        public int BookId { get; set; }
        public int BookStoreId { get; set; }
        public Book Book { get; set; }
        public BookStore BookStore { get; set; }
    }
}
