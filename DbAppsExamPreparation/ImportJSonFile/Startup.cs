namespace ImportJSonFile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using CodeFirstPhonebook.Data;
    using CodeFirstPhonebook.Models;

    public class Startup
    {
        public static void Main()
        {
            var context = new PhonebookContext();
            var reader = new StreamReader(@"../../contacts.json");

            var info = reader.ReadToEnd();

            var contacts = JsonConvert.DeserializeObject<ICollection<JSonContact>>(info);

            foreach (var contact in contacts)
            {
                try
                {
                    ImportContactToDatabase(contact, context);
                    Console.WriteLine("Contact {0} imported", contact.Name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
        }

        private static void ImportContactToDatabase(JSonContact jSonContact, PhonebookContext context)
        {
            if (jSonContact.Name == null)
            {
                throw new ArgumentException("Name is required");
            }

            var contact = new Contact()
            {
                Name = jSonContact.Name,
                Company = jSonContact.Company,
                Position = jSonContact.Position,
                SiteUrl = jSonContact.SiteUrl,
                Note = jSonContact.Note
            };

            if (jSonContact.Emails != null)
            {
                contact.Emails = jSonContact.Emails
                    .Select(e => new Email()
                    {
                        EmailAddress = e
                    })
                    .ToList();
            }

            if (jSonContact.Phones != null)
            {
                contact.Phones = jSonContact.Phones
                    .Select(p => new Phone()
                    {
                        PhoneNumber = p
                    })
                    .ToList();
            }

            context.Contacts.Add(contact);

            context.SaveChanges();
        }
    }
}
