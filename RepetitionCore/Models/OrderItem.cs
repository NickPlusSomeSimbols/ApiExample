using RepetitionCore.Abstractions;

namespace RepetitionCore.Models
{
    public class OrderItem : BaseEntity
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
