
namespace BooksStore.Data
{
    using System.Data.Entity;

    using Data.Migrations;
    using Models;

    public class BooksStoreDbContext : DbContext
    {
        public BooksStoreDbContext()
            : base("name=BooksStoreConnection")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BooksStoreDbContext, Configuration>());
        }

        public virtual IDbSet<Book> Books { get; set; }

        public virtual IDbSet<Review> Reviews { get; set; }

        public virtual IDbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithMany(b => b.Authors);

            modelBuilder.Entity<Review>()
                .HasRequired(r => r.Author)
                .WithMany(a => a.Reviews);

            modelBuilder.Entity<Review>()
                .HasRequired(r => r.Book)
                .WithMany(b => b.Reviews);
        }
    }
}

