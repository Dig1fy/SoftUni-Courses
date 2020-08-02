namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var mostCraziestAuthors = context.Authors.Select(x => new
            {
                //Microsoft's last update throws an error if we order the data after the materialization. Some InMemory issue...so we need to .ToArray() twice as well.
                AuthorName = x.FirstName + " " + x.LastName,
                Books = x.AuthorsBooks.OrderByDescending(c=>c.Book.Price).Select(y => new
                {
                    BookName = y.Book.Name,
                    BookPrice = y.Book.Price.ToString("F2")
                })
                 .ToArray()
            })
                .ToArray()
                .OrderByDescending(a => a.Books.Count())
                .ThenBy(a => a.AuthorName)
                .ToArray();

            var jsonResult = JsonConvert.SerializeObject(mostCraziestAuthors, Formatting.Indented);
            return jsonResult;
           
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            //The StringWriter will need it later to populate the data inside
            var stringBuilder = new StringBuilder();

            var books = context.Books
                .Where(d => d.PublishedOn < date && d.Genre == Genre.Science)
                .ToArray()
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Take(10)
                .Select(x => new ExportBookDto
                {
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                    Pages = x.Pages
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportBookDto[]), new XmlRootAttribute("Books"));

            //No idea...
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var stringWriter = new StringWriter(stringBuilder))
            {
                xmlSerializer.Serialize(stringWriter, books, namespaces);
            }

            return stringBuilder.ToString().Trim();
        }
    }
}