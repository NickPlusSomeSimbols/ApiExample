using Microsoft.EntityFrameworkCore;
using RepetitionCore.Models;

namespace RepetitionInfrastructure
{
    public class RepetitionDbContext : DbContext 
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        
        public RepetitionDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}