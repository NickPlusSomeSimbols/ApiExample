using RepetitionCore.Abstractions;
using RepetitionCore.Models.Enums;

namespace RepetitionCore.Models
{
    public class OrderDtoCreate : BaseEntity
    {
        public float Price{ get; set; }
        public OrderState State { get; set; }
        public ICollection<OrderItem>? Items { get; set; }
        public string Username { get; set; }
    }
}
