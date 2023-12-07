using RepetitionCore.Abstractions;
using RepetitionCore.IdentityAuth;

namespace RepetitionCore.Models
{
    public class Order : BaseEntity
    {
        public string CreationDate { get; set; }
        public float Price{ get; set; }
        public ICollection<OrderItem>? Items { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
