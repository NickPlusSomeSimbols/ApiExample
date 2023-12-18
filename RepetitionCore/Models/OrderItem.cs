using RepetitionCore.Abstractions;

namespace RepetitionCore.Models
{
    public class OrderItem : BaseEntity
    {
        public int Price { get; set; }
        public int Amount { get; set; }
        public int BookId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
