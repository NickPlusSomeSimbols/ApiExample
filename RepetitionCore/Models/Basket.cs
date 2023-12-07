using RepetitionCore.Abstractions;
using RepetitionCore.IdentityAuth;

namespace RepetitionCore.Models
{
    public class Basket : BaseEntity
    {
        public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
