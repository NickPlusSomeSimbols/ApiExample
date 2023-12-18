using RepetitionCore.Abstractions;
using RepetitionCore.IdentityAuth;
using RepetitionCore.Models.Enums;

namespace RepetitionCore.Models
{
    public class OrderDtoUpdate 
    {
        public int OrderId { get; set; }
        public int OrderItemid { get; set; }
        public int Amount { get; set; }
    }
}
