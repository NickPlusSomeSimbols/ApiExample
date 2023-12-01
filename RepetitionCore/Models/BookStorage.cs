using RepetitionCore.Abstractions;

namespace RepetitionCore.Models
{
    public class BookStorage : BaseEntity
    {
        public int BookAmount { get; set; }
        public string BookId { get; set; }
        public string BookStoreId{ get; set; }
        public Book Book { get; set; }
        public BookStore BookStore { get; set; }
    }
}
