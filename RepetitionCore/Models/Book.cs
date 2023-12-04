using RepetitionCore.Abstractions;

namespace RepetitionCore.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? PublicationDate { get; set; }
    }
}