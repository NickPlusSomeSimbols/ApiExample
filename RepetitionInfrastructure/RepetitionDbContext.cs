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

            modelBuilder.Entity<BookStorage>()
                .HasOne(bs => bs.BookStore)
                .WithOne(bs => bs.BookStorage)
                .HasForeignKey<BookStore>(bs => bs.BookStorageId);

            modelBuilder.Entity<BookStore>()
                .HasOne(bs => bs.BookStorage)
                .WithOne(bs => bs.BookStore)
                .HasForeignKey<BookStorage>(bs => bs.BookStoreId);
        }
    }
}