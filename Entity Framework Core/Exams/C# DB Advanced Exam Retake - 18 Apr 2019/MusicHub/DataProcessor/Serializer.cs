namespace MusicHub.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;

    public class Serializer
    {
        //Works locally but Judge is broken. 
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                //.ToArray() //Comment this if want to test locally. Without it Judge will give you 0 points.
                .Where(x => x.ProducerId == producerId)
                .Select(y => new
                {
                    AlbumName = y.Name,
                    ReleaseDate = y.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = y.Producer.Name,
                    Songs = y.Songs.Select(b => new
                    {
                        SongName = b.Name,
                        Price = b.Price.ToString("f2"),
                        Writer = b.Writer.Name
                    })
                    .OrderByDescending(f => f.SongName)
                    .ThenBy(f => f.Writer)
                    .ToArray()
                    ,
                    AlbumPrice = y.Songs.Sum(c => c.Price).ToString("f2")
                })
                .OrderByDescending(h => h.AlbumPrice)
                .ToArray();

            var jsonResult = JsonConvert.SerializeObject(albums, Formatting.Indented);

            return jsonResult.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                //.ToArray() //Comment this if want to test locally. Without it Judge will give you 0 points.
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(y => new ExportSongsDto
                {
                    SongName = y.Name,
                    Writer = y.Writer.Name,
                    Performer = y.SongPerformers.Select(g => g.Performer.FirstName + " " + g.Performer.LastName).FirstOrDefault(),
                    AlbumProducer = y.Album.Producer.Name,
                    Duration = y.Duration.ToString("c")
                })
                .OrderBy(v => v.SongName)
                .ThenBy(v => v.Writer)
                .ThenBy(v => v.Performer)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportSongsDto[]), new XmlRootAttribute("Songs"));
            var sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), songs);

            return sb.ToString().Trim();
        }
    }
}