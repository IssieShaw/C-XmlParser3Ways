namespace Xml2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Directory.GetCurrentDirectory();
            filePath = Directory.GetParent(filePath)?.Parent?.Parent?.FullName ?? string.Empty; filePath = Path.Join(filePath, "SampleXml\\books.xml");
            List<Book> bookListWithDescendant = Book.ParseBooks(filePath);
            List<Book> bookListWithElement = Book.ParseBooksWithElement(filePath);
            List<Book> bookListWithLinq = Book.ParseBooksWithLinq(filePath);
            Console.WriteLine(bookListWithLinq.Count);
        }
    }
}