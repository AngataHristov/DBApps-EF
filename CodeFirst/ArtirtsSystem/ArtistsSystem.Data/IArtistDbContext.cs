namespace ArtistsSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using ArtistsSystem.Models;
    using System.Data.Entity.Infrastructure;

    public interface IArtistDbContext
    {
         IDbSet<Album> Albums { get; set; }

         IDbSet<Song> Songs { get; set; }

         IDbSet<Artist> Artists { get; set; }

         IDbSet<Image> Images { get; set; }

         IDbSet<Category> Categories { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
