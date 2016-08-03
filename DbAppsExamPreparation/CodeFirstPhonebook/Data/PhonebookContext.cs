namespace CodeFirstPhonebook.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CodeFirstPhonebook.Models;
    using CodeFirstPhonebook.Migrations;

    public class PhonebookContext : DbContext
    {
        public PhonebookContext()
            : base("PhonebookContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<PhonebookContext, Configuration>());
        }

        public virtual IDbSet<Contact> Contacts { get; set; }

        public virtual IDbSet<Phone> Phones { get; set; }

        public virtual IDbSet<Email> Emails { get; set; }    
    }
}
