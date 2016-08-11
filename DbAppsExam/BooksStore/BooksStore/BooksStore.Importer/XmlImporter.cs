namespace BooksStore.Importer
{
    using Data;
    using Models;
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class XmlImporter
    {
        private readonly BooksStoreDbContext context;

        private string filePath;

        public XmlImporter(BooksStoreDbContext data, string filePath)
        {
            this.context = data;
            this.filePath = filePath;
        }

        public void Import()
        {
            var xmlBooks = XElement.Load(filePath).Elements();

            foreach (var xmlBook in xmlBooks)
            {
                this.ImportBook(xmlBook);
            }
        }

        private void ImportBook(XElement xmlBook)
        {
            var currentBook = new Book();
            currentBook.Title = xmlBook.Element("title").Value;

            var isbn = xmlBook.Element("isbn");
            if (isbn != null)
            {
                var bookExists = this.context.Books
                     .Any(b => b.ISBN == isbn.Value);
                if (bookExists)
                {
                    throw new ArgumentException("isbn already exists");
                }

                currentBook.ISBN = isbn.Value;
            }

            var price = xmlBook.Element("price");
            if (price != null)
            {
                currentBook.Price = decimal.Parse(price.Value);
            }

            var webSite = xmlBook.Element("web-site");
            if (webSite != null)
            {
                currentBook.WebSite = webSite.Value;
            }

            this.AddAuthorsToBook(xmlBook, currentBook);
            this.AddReviewsToBook(xmlBook, currentBook);

            this.context.Books.Add(currentBook);
            this.context.SaveChanges();
        }

        private void AddAuthorsToBook(XElement xmlBook, Book currentBook)
        {
            var xmlAuthors = xmlBook.Element("authors");
            if (xmlAuthors != null)
            {
                foreach (var xmlAuthor in xmlAuthors.Elements("author"))
                {
                    var authorName = xmlAuthor.Value;
                    var author = this.GetAuthor(authorName);

                    currentBook.Authors.Add(author);
                }
            }
        }

        private void AddReviewsToBook(XElement xmlBook, Book currentBook)
        {
            var xmlReviews = xmlBook.Element("reviews");
            if (xmlReviews != null)
            {
                foreach (var xmlReview in xmlReviews.Elements("review"))
                {
                    var reviewDate = xmlReview.Attribute("date");
                    var authorName = xmlReview.Attribute("author");
                    var review = new Review()
                    {
                        Content = xmlReview.Value,
                        CreatedOn = reviewDate == null ? DateTime.Now : DateTime.Parse(reviewDate.Value),
                    };

                    if (authorName != null)
                    {
                        review.Author = this.GetAuthor(authorName.Value);
                    }

                    currentBook.Reviews.Add(review);
                }
            }
        }

        private Author GetAuthor(string authorName)
        {
            var author = this.context.Authors
                   .FirstOrDefault(a => a.Name == authorName);

            if (author == null)
            {
                author = new Author()
                {
                    Name = authorName
                };
            }

            return author;
        }


    }
}
