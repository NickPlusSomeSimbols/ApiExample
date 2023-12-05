using RepetitionCore.Abstractions;

namespace RepetitionCore.Models
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string DeathDate { get; set; }
    }
}
