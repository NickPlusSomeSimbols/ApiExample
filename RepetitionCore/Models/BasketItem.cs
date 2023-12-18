using RepetitionCore.Abstractions;

namespace RepetitionCore.Models
{
    public class BasketItem : BaseEntity
    {
        public float TotalPrice { get; set; }
        public int Amount { get; set; }
        public int BookId { get; set; }
        public int BasketId { get; set; }
        public Book Book { get; set; }
    }
}
