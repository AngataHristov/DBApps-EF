namespace BooksStore.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<BooksStoreDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "BooksStore.Data.BooksStoreDbContext";
        }

        protected override void Seed(BooksStoreDbContext context)
        {
        }
    }
}
