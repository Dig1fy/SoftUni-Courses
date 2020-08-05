namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var listOfWriters = new List<Writer>();

            var writersDtos = JsonConvert.DeserializeObject<JsonImportWritersDto[]>(jsonString);

            foreach (var writerDto in writersDtos)
            {
                if (!IsValid(writerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };

                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
                listOfWriters.Add(writer);
            }

            context.Writers.AddRange(listOfWriters);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var listOfProducers = new List<Producer>();

            var producersDtos = JsonConvert.DeserializeObject<ImportProducersAndAlbumsDto[]>(jsonString);

            foreach (var producerDto in producersDtos)
            {
                //If ANY of the albums is incorrect, we should skip the entire entity (producer)
                if (!IsValid(producerDto) || !producerDto.Albums.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer
                {
                    Name = producerDto.Name,
                    Pseudonym = producerDto.Pseudonym,
                    PhoneNumber = producerDto.PhoneNumber
                };

                foreach (var albumDto in producerDto.Albums)
                {
                    producer.Albums.Add(new Album
                    {
                        Name = albumDto.Name,
                        ReleaseDate = DateTime.ParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    });

                }

                var message = producer.PhoneNumber == null ?
                    string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count) :
                    string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count);

                sb.AppendLine(message);
                listOfProducers.Add(producer);
            }

            context.Producers.AddRange(listOfProducers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongsDto[]), new XmlRootAttribute("Songs"));

            var sb = new StringBuilder();
            var listOfSongs = new List<Song>();

            using (var stringReader = new StringReader(xmlString))
            {
                var xmlDtos = (ImportSongsDto[])xmlSerializer.Deserialize(stringReader);

                foreach (var songDto in xmlDtos)
                {
                    if (!IsValid(songDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var genre = Enum.TryParse(songDto.Genre, out Genre genreResult);
                    var album = context.Albums.Find(songDto.AlbumId);
                    var writer = context.Writers.Find(songDto.WriterId);
                    var songTitle = listOfSongs.Any(s => s.Name == songDto.Name);

                    if (!genre || album == null || writer == null || songTitle)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var song = new Song
                    {
                        Name = songDto.Name,
                        Duration = TimeSpan.Parse(songDto.Duration),
                        CreatedOn = DateTime.ParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Genre = (Genre)Enum.Parse(typeof(Genre), songDto.Genre),
                        AlbumId = songDto.AlbumId,
                        WriterId = songDto.WriterId,
                        Price = songDto.Price
                    };

                    listOfSongs.Add(song);
                    sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
                }

                context.Songs.AddRange(listOfSongs);
                context.SaveChanges();

                return sb.ToString();
            }
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPerformerDto[]), new XmlRootAttribute("Performers"));
            var sb = new StringBuilder();
            var listOfPerformers = new List<Performer>();

            using (var stringReader = new StringReader(xmlString))
            {
                var perfDtos = (ImportPerformerDto[])xmlSerializer.Deserialize(stringReader);

                foreach (var per in perfDtos)
                {
                    if (!IsValid(per))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var songsCount = context.Songs.Count(x => per.PerformersSongs.Any(y => y.Id == x.Id));

                    if (songsCount != per.PerformersSongs.Length)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var performer = new Performer
                    {
                        FirstName = per.FirstName,
                        LastName = per.LastName,
                        Age = per.Age,
                        NetWorth = per.NetWorth
                    };

                    listOfPerformers.Add(performer);
                    sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName, songsCount));
                }

                context.Performers.AddRange(listOfPerformers);
                context.SaveChanges();

                return sb.ToString().Trim();
            }
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return result;
        }
    }
}