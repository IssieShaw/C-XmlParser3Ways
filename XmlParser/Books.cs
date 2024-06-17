using System.Xml.Linq;

namespace Xml2
{
    internal class Book
    {
        public string? Author { get; internal set; }
        public string? Title { get; internal set; }
        public string? Genre { get; internal set; }
        public string? Price { get; internal set; }
        public string? PublishDate { get; internal set; }
        public string? Description { get; internal set; }

        public Book(
            string? author,
            string? title,
            string? genre,
            string? price,
            string? publishDate,
            string? description)
        {
            Author = author;
            Title = title;
            Genre = genre;
            Price = price;
            PublishDate = publishDate;
            Description = description;
        }

        public static List<Book> ParseBooks(string filePath)
        {
            List<Book> books = new();
            XDocument xmlDoc = XDocument.Load(filePath);

            foreach (var element in xmlDoc.Descendants("book"))
            {
                Book book = new(
                    element.Element("author")?.Value,
                    element.Element("title")?.Value,
                    element.Element("genre")?.Value,
                    element.Element("price")?.Value,
                    element.Element("publish_date")?.Value,
                    element.Element("description")?.Value
                );
                books.Add(book);
            }

            return books;
        }

        public static List<Book> ParseBooksWithElement(string filePath)
        {
            List<Book> books = new();
            XDocument xmlDoc = XDocument.Load(filePath);
            XElement? root = xmlDoc.Element("catalog");

            if (root != null)
            {
                foreach (XElement bookElement in root.Elements("book"))
                {
                    string? author = bookElement.Element("author")?.Value;
                    string? title = bookElement.Element("title")?.Value;
                    string? genre = bookElement.Element("genre")?.Value;
                    string? price = bookElement.Element("price")?.Value;
                    string? publishDate = bookElement.Element("publish_date")?.Value;
                    string? description = bookElement.Element("description")?.Value;

                    Book book = new Book(author, title, genre, price, publishDate, description);
                    books.Add(book);
                }
            }

            return books;
        }

        public static List<Book> ParseBooksWithLinq(string filePath)
        {
            XDocument xmlDoc = XDocument.Load(filePath);
            var books = from book in xmlDoc.Descendants("book")
                        select new Book(
                            book.Element("author")?.Value,
                            book.Element("title")?.Value,
                            book.Element("genre")?.Value,
                            book.Element("price")?.Value,
                            book.Element("publish_date")?.Value,
                            book.Element("description")?.Value
                        );

            return books.ToList();
        }
    }
}
