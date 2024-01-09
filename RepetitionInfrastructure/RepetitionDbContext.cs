using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepetitionCore.Models;
using RepetitionCore.IdentityAuth;

namespace RepetitionInfrastructure
{
    public class RepetitionDbContext : IdentityDbContext<ApplicationUser>
    {
        public RepetitionDbContext(DbContextOptions<RepetitionDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookStore> BookStores { get; set; }
        public DbSet<BookStorage> BookStorages { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<BookSoldReport> BookSoldReports { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<Book>()
                .HasIndex(u => u.Title)
                .IsUnique();

            modelBuilder.Entity<AuthorBook>()
                .HasIndex(u => new { u.AuthorId, u.BookId})
                .IsUnique();
        }
    }
}