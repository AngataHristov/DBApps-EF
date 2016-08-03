namespace ArtistsSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using ArtistsSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ArtistsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "ArtistsSystem.Data.ArtistsDbContext";
        }

        protected override void Seed(ArtistsDbContext context)
        {
            //context.Songs.AddOrUpdate(
            //    s => s.Title, new Song
            //    {
            //        Title = "chalga",
            //        Duration = 300,
            //        Album = context.Albums.FirstOrDefault()
            //    });

            //context.Albums.AddOrUpdate(
            //    a => a.Title, new Album
            //    {
            //        Title = "chalgii",
            //    });


            //context.SaveChanges();
        }
    }
}
