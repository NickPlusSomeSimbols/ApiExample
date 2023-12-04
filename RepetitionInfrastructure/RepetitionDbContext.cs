using Microsoft.EntityFrameworkCore;
using RepetitionCore.Models;

namespace RepetitionInfrastructure
{
    public class RepetitionDbContext : DbContext 
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookStore> BookStores { get; set; }
        public DbSet<BookStorage> BookStorages { get; set; }

        public RepetitionDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<Book>()
                .HasIndex(u => u.Title)
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