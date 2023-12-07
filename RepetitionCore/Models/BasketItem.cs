using RepetitionCore.Abstractions;

namespace RepetitionCore.Models
{
    public class BasketItem : BaseEntity
    {
        public int TotalPrice { get; set; }
        public int TotalAmount { get; set; }
        public int BookId { get; set; }
        public int BasketId { get; set; }
        public Book Book { get; set; }
        public Basket Basket { get; set; }
    }
}
