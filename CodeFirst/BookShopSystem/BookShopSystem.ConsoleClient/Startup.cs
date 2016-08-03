namespace BookShopSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.IO;
    using System.Globalization;

    using BookShopSystem.Data;
    using BookShopSystem.Models;
    using BookShopSystem.Models.Enums;

    public class Startup
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var context = new BookShopContext();
            var r = context.Books.Count();

            using (context)
            {
                //var books = context.Books
                //    .Where(b => b.ReleaseDate != null && b.ReleaseDate.Value.Year > 2000)
                //    .Select(b => b.Title)
                //    .ToList();

                //var authors = context.Authors
                //   .Where(a => a.Books.Where(b => b.ReleaseDate.Value.Year < 1990).Any())
                //   .Select(a => new
                //   {
                //       a.FirstName,
                //       a.LastName
                //   })
                //   .ToList();

                //var authors2 = context.Authors
                //    .OrderByDescending(a => a.Books.Count)
                //    .Select(a => new
                //    {
                //        a.FirstName,
                //        a.LastName,
                //        BooksCount = a.Books.Count
                //    })
                //    .ToList();

                //var books1 = context.Books
                //    .Where(b => b.Author.FullName == "Pedro Shoshov")
                //    .OrderByDescending(b => b.ReleaseDate)
                //    .ThenBy(b => b.Title)
                //    .Select(b => new
                //    {
                //        b.Title,
                //        b.ReleaseDate,
                //        b.Copies
                //    })
                //    .ToList();

                //var books2 = context.Categories
                //    .OrderByDescending(c => c.Books.Count)
                //    .Select(c => new
                //    {
                //        CategoryName = c.Name,
                //        BooksCount = c.Books.Count,
                //        Books = c.Books
                //            .Take(3)
                //            .OrderByDescending(b => b.ReleaseDate)
                //            .ThenBy(b => b.Title)
                //            .Select(b => new
                //            {
                //                Title = b.Title,
                //                RelDate = b.ReleaseDate
                //            })
                //    })
                //    .ToList();

                //foreach (var item in books2)
                //{
                //    Console.WriteLine("--{0}: {1} books", item.CategoryName, item.BooksCount);

                //    foreach (var b in item.Books)
                //    {
                //        Console.WriteLine("{0} ({1})", b.Title, b.RelDate);
                //    }
                //}

                var books = context.Books
                    .Take(3)
                    .ToList();

                foreach (var book in books)
                {
                    Console.WriteLine("---{0}", book.Title);

                    foreach (var b in book.RelatedBooks)
                    {
                        Console.WriteLine(b.Title);
                    }
                }
            }
        }
    }
}
