namespace BookShopSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using BookShopSystem.Models;
    using BookShopSystem.Models.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShopContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "BookShopSystem.Data.BookShopContext";
        }

        protected override void Seed(BookShopContext context)
        {
        //    var category = new Category()
        //    {
        //        Name = "Prostotii"
        //    };

        //    var author = new Author()
        //    {
        //        FirstName = "Gancho",
        //        LastName = "Asenov"
        //    };

        //    var book = new Book()
        //    {
        //        Title = "Tupi istorii",
        //        ReleaseDate = DateTime.Now,
        //        Price = 10.5m,
        //        EditionType = EditionType.Normal,
        //        Description = "lqlqlq",
        //        Copies = 1000,
        //        Author = author,
        //        AgeRestriction = AgeRestriction.Adult
        //    };

        //    context.Categories.AddOrUpdate(category);
        //    context.Books.AddOrUpdate(book);
        //    context.Authors.AddOrUpdate(author);
        }
    }
}
