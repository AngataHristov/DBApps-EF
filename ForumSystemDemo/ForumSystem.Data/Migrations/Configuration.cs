namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Models;
    using Models.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<ForumContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "ForumSystem.Data.ForumContext";
        }

        protected override void Seed(ForumContext context)
        {
            context.Users.AddOrUpdate(
                u => u.UserName,
                new User()
                {
                    UserInfo = new UserInfo()
                    {
                        FirstName = "Gosho",
                        LastName = "Penchov",
                        Age = 18
                    },

                    Gender = Gender.Male,
                    RegisteredOn = DateTime.Now,
                    UserName = "jingata"
                });

            context.SaveChanges();
        }
    }
}
