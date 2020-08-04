namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(x => x.Rating >= rating && x.Projections.Any(y => y.Tickets.Count > 0))
                .OrderByDescending(p => p.Rating)
                .ThenByDescending(s => s.Projections.Sum(g => g.Tickets.Sum(o => o.Price)))
                .Select(b => new
                {
                    MovieName = b.Title,
                    Rating = b.Rating.ToString("f2"),
                    TotalIncomes = b.Projections.Sum(a => a.Tickets.Sum(z => z.Price)).ToString("f2"),
                    Customers = b.Projections.SelectMany(l => l.Tickets).Select(c => new
                    {
                        FirstName = c.Customer.FirstName,
                        LastName = c.Customer.LastName,
                        Balance = c.Customer.Balance.ToString("f2")
                    })
                    .OrderByDescending(w => w.Balance)
                    .ThenBy(w => w.FirstName)
                    .ThenBy(w => w.LastName)
                    .ToArray()
                })
                    .Take(10)
                .ToArray();

            var jsonMovies = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);

            return jsonMovies;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Where(a => a.Age >= age)
                .OrderByDescending(y => y.Tickets.Sum(h => h.Price))
                .Take(10)
                .Select(c => new XMLExportCustomersDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SpentMoney = c.Tickets.Sum(b => b.Price).ToString("f2"),
                    SpentTime = TimeSpan.FromSeconds(c.Tickets.Sum(z => z.Projection.Movie.Duration.TotalSeconds)).ToString(@"hh\:mm\:ss")
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(XMLExportCustomersDto[]), new XmlRootAttribute("Customers"));
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString();
        }
    }
}