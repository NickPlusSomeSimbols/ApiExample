using RepetitionCore.IdentityAuth;
using RepetitionCore.Models;

namespace RepetitionCore.Dto.Basket
{
    public class BasketDto
    {
        public int Id { get; set; }
        public ICollection<RepetitionCore.Models.BasketItem> BasketItems { get; set; } = new List<RepetitionCore.Models.BasketItem>(); // just BasketItem isn't accepted idk why
    }
}
