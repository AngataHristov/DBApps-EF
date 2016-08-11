namespace BooksStore.Importer
{
    using Data;
    using Models;
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class Startup
    {
        public static void Main()
        {
            var context = new BooksStoreDbContext();
            var filePath = @"..\..\imports.xml";
            //var xmlImporter = new XmlImporter(context, filePath);

            //xmlImporter.Import();

            //Search();
        }

        public static void Search(BooksStoreDbContext context)
        {
            var xmlQueries = XElement.Load(@"..\..\..\reviews-queries.xml").Elements();
            var result = new XElement("search-result");

            foreach (var xmlQuery in xmlQueries)
            {
                var queryInReviews = context.Reviews.AsQueryable();

                if (xmlQuery.Attribute("type").Value == "by-period")
                {
                    var startDate = DateTime.Parse(xmlQuery.Element("start-date").Value);
                    var endDate = DateTime.Parse(xmlQuery.Element("end-date").Value);

                    queryInReviews = queryInReviews.Where(r => (startDate <= r.CreatedOn && r.CreatedOn <= endDate));
                }
                else if (xmlQuery.Attribute("type").Value == "by-authokdr")
                {
                    var authorName = xmlQuery.Element("author-name").Value;

                    queryInReviews.Where(r => r.Author.Name == authorName);
                }

                var resultSet = queryInReviews
                     .OrderBy(r => r.CreatedOn)
                     .ThenBy(r => r.Content)
                     .Select(r => new
                     {
                         Date = r.CreatedOn,
                         Content = r.Content,
                         Book = new
                         {
                             Title = r.Book.Title,
                             Authors = r.Book.Authors
                                 .AsQueryable()
                                 .OrderBy(a => a.Name)
                                 .Select(a => a.Name),
                             ISBN = r.Book.ISBN,
                             URL = r.Book.WebSite
                         }
                     }).ToList();

                var xmlResultSet = new XElement("result-set");
                foreach (var reviewInResult in resultSet)
                {
                    var xmlReview = new XElement("review");

                    xmlReview.Add(new XElement("date", reviewInResult.Date.ToString("d-MMM-yyyy")));
                    xmlReview.Add(new XElement("content", reviewInResult.Content));

                    var xmlBook = new XElement("book");

                    xmlBook.Add(new XElement("title", reviewInResult.Book.Title));

                    if (reviewInResult.Book.Authors != null)
                    {
                        var bookAuthors = string.Join(", ", reviewInResult.Book.Authors);
                        xmlBook.Add(new XElement("authors", bookAuthors));
                    }

                    var bookIsbn = reviewInResult.Book.ISBN;
                    if (bookIsbn != null)
                    {
                        xmlBook.Add(new XElement("isbn", bookIsbn));
                    }

                    var bookUrl = reviewInResult.Book.URL;
                    if (bookUrl != null)
                    {
                        xmlBook.Add(new XElement("url", bookUrl));
                    }

                    xmlReview.Add(xmlBook);
                    xmlResultSet.Add(xmlReview);
                }


                result.Add(xmlResultSet);
            }
        }
    }
}
