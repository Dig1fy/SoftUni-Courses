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
            var writersDtos = JsonConvert.DeserializeObject<JsonImportWritersDto[]>(jsonString);
            var sb = new StringBuilder();
            var listOfValidWriters = new List<Writer>();

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

                listOfValidWriters.Add(writer);
                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(listOfValidWriters);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var prodDtos = JsonConvert.DeserializeObject<JsonImportProducersAlbumsDto[]>(jsonString);
            var sb = new StringBuilder();
            var listOfProducers = new List<Producer>();

            foreach (var prodDto in prodDtos)
            {
                if (!IsValid(prodDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //If there is invalid album (even one), we should skip adding the entire entity (Producer)
                var isInvalidAlbum = prodDto.Albums.Any(x => !IsValid(x));

                if (isInvalidAlbum)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer
                {
                    Name = prodDto.Name,
                    Pseudonym = prodDto.Pseudonym,
                    PhoneNumber = prodDto.PhoneNumber
                };

                //After passing the album's validation, we could add all albums to the producer
                foreach (var album in prodDto.Albums)
                {
                   var currentAlbum =  new Album 
                   {
                       Name = album.Name, 
                       ReleaseDate = DateTime.ParseExact(album.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None)
                   };

                    producer.Albums.Add(currentAlbum);
                }

                listOfProducers.Add(producer);

                //We have 2 outputs for successfully added producer so we need to check if producer has pseudonym or not
                if (producer.PhoneNumber == null)
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count));
                }
                else
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count));
                }                
            }

            context.Producers.AddRange(listOfProducers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var listOfValidSongs = new List<Song>();

            var xmlSerializer = new XmlSerializer(typeof(XmlImportSongsDto[]), new XmlRootAttribute("Songs"));

            using (var stringReader = new StringReader(xmlString))
            {
                //deserializing the string reader will return an object so we need to explicitly cast it to the array of Dtos
                var songsDtos = (XmlImportSongsDto[])xmlSerializer.Deserialize(stringReader);

                foreach (var songDto in songsDtos)
                {
                    if (!IsValid(songDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!songDto.AlbumId.HasValue)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isWriterValid = context.Writers.Find(songDto.WriterId);
                    var isAlbumValid = context.Albums.Find(songDto.AlbumId);
                    var isGenreValid = Enum.TryParse(songDto.Genre, out Genre genre);

                    if (isWriterValid == null || isAlbumValid == null || !isGenreValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime createdOnResult;
                    var isCreatedOnValid = DateTime.TryParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out createdOnResult);

                    if (!isCreatedOnValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //after passing all validations, we can create our entities and add them to the context
                    //Genre genreResult;

                    var song = new Song
                    {
                        Name = songDto.Name,
                        Duration = TimeSpan.Parse(songDto.Duration),
                        CreatedOn = createdOnResult,
                        Genre = genre /*(Genre)Enum.Parse(typeof(Genre), songDto.Genre)*/,
                        AlbumId = songDto.AlbumId,
                        WriterId = songDto.WriterId,
                        Price = songDto.Price
                    };

                    listOfValidSongs.Add(song);
                    sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
                }

                context.Songs.AddRange(listOfValidSongs);
                context.SaveChanges();

                return sb.ToString().Trim();
            }
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var listOfPerformers = new List<Performer>();
            var listOfSongsPerformers = new List<SongPerformer>();

            var xmlSerializer = new XmlSerializer(typeof(XmlImportSongsPerformersDto[]), new XmlRootAttribute("Performers"));

            using (var stringReader = new StringReader(xmlString))
            {
                var prodDtos = (XmlImportSongsPerformersDto[])xmlSerializer.Deserialize(stringReader);

                foreach (var perfDto in prodDtos)
                {
                    if (!IsValid(perfDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var performer = new Performer
                    {
                        FirstName = perfDto.FirstName,
                        LastName = perfDto.LastName,
                        Age = perfDto.Age,
                        NetWorth = perfDto.NetWorth
                    };

                    var areAllSongsValid = true;
                    var tempListOfSongPerformers = new List<SongPerformer>();
                    

                    //Check if all songs pass the validation and only then add them to the performer
                    foreach (var songDto in perfDto.PerformersSongs.Distinct())
                    {
                        if (!IsValid(songDto) || !context.Songs.Any(x=>x.Id == songDto.Id))
                        {
                            areAllSongsValid = false;
                            sb.AppendLine(ErrorMessage);
                            break;
                        }

                        var songPerformer = new SongPerformer
                        {
                            Performer = performer,
                            SongId = songDto.Id 
                        };

                        tempListOfSongPerformers.Add(songPerformer);
                    }

                    if (areAllSongsValid)
                    {
                        listOfPerformers.Add(performer);

                        listOfSongsPerformers.AddRange(tempListOfSongPerformers);
                        sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName, tempListOfSongPerformers.Count));

                        tempListOfSongPerformers.Clear();
                    }
                }

                context.Performers.AddRange(listOfPerformers);
                context.SongsPerformers.AddRange(listOfSongsPerformers);
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