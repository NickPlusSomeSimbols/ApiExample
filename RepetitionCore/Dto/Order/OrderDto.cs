using RepetitionCore.Abstractions;
using RepetitionCore.Models.Enums;

namespace RepetitionCore.Models
{
    public class OrderDto
    {
        public string CreationDate { get; set; }
        public float Price{ get; set; }
        public ICollection<OrderItem>? Items { get; set; }
        public OrderState State { get; set; }
    }
}
