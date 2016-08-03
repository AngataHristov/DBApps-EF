namespace CodeFirstPhonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CodeFirstPhonebook.Data;
    using CodeFirstPhonebook.Models;

    public class Startup
    {
        public static void Main()
        {
            var context = new PhonebookContext();

            var people = context.Contacts
                .Select(c => new
                {
                    ContactName = c.Name,
                    ContactPhones = c.Phones.Select(p => p.PhoneNumber),
                    ContactEmails = c.Emails.Select(e => e.EmailAddress)
                })
                .ToList();

            foreach (var person in people)
            {
                Console.WriteLine(person.ContactName);
                Console.WriteLine("Phones: {0}", string.Join(", ",person.ContactPhones));
                Console.WriteLine("Emails: {0}",string.Join(", ",person.ContactEmails));
            }
        }
    }
}
