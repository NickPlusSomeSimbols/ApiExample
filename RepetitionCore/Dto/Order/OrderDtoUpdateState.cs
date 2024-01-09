using RepetitionCore.Abstractions;
using RepetitionCore.Models.Enums;

namespace RepetitionCore.Models
{
    public class OrderDtoUpdateState 
    {
        public int OrderId { get; set; }
        public OrderState State { get; set; }
    }
}
