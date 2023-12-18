using RepetitionCore.Abstractions;

namespace RepetitionCore.Models
{
    public class OrderDtoCreate : BaseEntity
    {
        public float Price{ get; set; }
        public ICollection<OrderItem>? Items { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
