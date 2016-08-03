namespace ArtistsSystem.Data
{
    using System.Data.Entity;

    using ArtistsSystem.Models;
    using ArtistsSystem.Data.Migrations;

    public class ArtistsDbContext : DbContext, IArtistDbContext
    {
        public ArtistsDbContext()
            : base("ArtistsSystem")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ArtistsDbContext, Configuration>());
        }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Artist>()
                .Property(a => a.Name);

            modelBuilder
                .Entity<Artist>()
                .HasMany(a => a.Albums)
                .WithMany();

            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
