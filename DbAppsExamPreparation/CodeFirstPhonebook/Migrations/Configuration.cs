namespace CodeFirstPhonebook.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using CodeFirstPhonebook.Data;
    using CodeFirstPhonebook.Models;

    public sealed class Configuration : DbMigrationsConfiguration<PhonebookContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "CodeFirstPhonebook.Data.PhonebookContext";
        }

        protected override void Seed(PhonebookContext context)
        {
            var Email = new Email()
            {
                EmailAddress = "peshkata@abv.bg"
            };

            var phone = new Phone()
            {
                PhoneNumber = "0884856737"
            };

            var contact = new Contact()
            {
                Company = "Zagorka",
                Name = "geitaka",
                Note = "something",
                Position = "there",
                SiteUrl = "babiniDivotii"
            };

            contact.Phones.Add(phone);
            contact.Emails.Add(Email);

            context.Contacts.AddOrUpdate(c => c.Name, contact);

            context.SaveChanges();
        }
    }
}
