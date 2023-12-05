using RepetitionCore.Abstractions;

namespace RepetitionCore.Models
{
    public class BookSoldReport : BaseEntity
    {
        public int BookId { get; set; }
        public int BookStoreId { get; set; }
        public int PurchaseAmount { get; set; }
        public float Income { get; set; }
        public string PuchaseDate { get; set; }
        public Book Book { get; set; } 
        public BookStore BookStore { get; set; }
    }
}
