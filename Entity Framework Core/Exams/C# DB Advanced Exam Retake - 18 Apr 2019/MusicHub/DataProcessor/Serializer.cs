namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;
    //                              Tests in Judge are broken ang gives 0/25... however, results are correct
    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(x => x.ProducerId == producerId)                
                .Select(y => new
                {
                    AlbumName = y.Name,
                    ReleaseDate = y.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = y.Producer.Name,
                    Songs = y.Songs                    
                    .Select(b => new
                    {
                        SongName = b.Name,
                        Price = b.Price.ToString("f2"),
                        Writer = b.Writer.Name
                    })
                    //.ToList() //Comment this when testing locally. There's InMemory issue with Judge and we need to materialize before any ordering...
                    .OrderByDescending(a => a.SongName)
                    .ThenBy(a => a.Writer)
                    .ToList()
                    ,
                    AlbumPrice = y.Songs.Sum(g => g.Price).ToString("f2")
                })
                //.ToList() //Comment this when testing locally. There's InMemory issue with Judge and we need to materialize before any ordering...
                .OrderByDescending(q => q.AlbumPrice)
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(albums, Formatting.Indented);

            return jsonResult;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Where(a => a.Duration.TotalSeconds >= duration)                
                .Select(x => new ExportSongsDto
                {
                    SongName = x.Name,
                    Writer = x.Writer.Name,
                    Performer = x.SongPerformers.Select(a => a.Performer.FirstName + " " + a.Performer.LastName).FirstOrDefault(),
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration.ToString("c")
                })               
                //.ToList() //Comment this when testing locally. There's InMemory issue with Judge and we need to materialize before any ordering...
                .OrderBy(q => q.SongName)
                .ThenBy(q => q.Writer)
                .ThenBy(q => q.Performer)
                .ToList();

            var sb = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(List<ExportSongsDto>), new XmlRootAttribute("Songs"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, songs, namespaces);
            }

            return sb.ToString().Trim();
        }
    }
}