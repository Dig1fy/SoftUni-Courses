namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Cinema.Data;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var movieDtos = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);
            var stringBuilder = new StringBuilder();
            var listOfValidMovies = new List<Movie>();

            foreach (var movieDto in movieDtos)
            {
                var isTitleDuplicated = listOfValidMovies.Any(x => x.Title == movieDto.Title);
                var isEnumValid = Enum.TryParse(typeof(Genre), movieDto.Genre, out object genre);
                var isValidDto = IsValid(movieDto);

                if (!IsValid(movieDto) || isTitleDuplicated || !isEnumValid)
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                //if we pass the validations, we could create and add the movie to the db
                var movie = Mapper.Map<Movie>(movieDto);

                listOfValidMovies.Add(movie);

                stringBuilder.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating.ToString("F2")));
            }

            context.Movies.AddRange(listOfValidMovies);
            context.SaveChanges();

            return stringBuilder.ToString();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallSeatsDtos = JsonConvert.DeserializeObject<ImportHallSeatsDto[]>(jsonString);

            var sb = new StringBuilder();
            var listOfHalls = new List<Hall>();

            foreach (var hallDto in hallSeatsDtos)
            {
                if (!IsValid(hallDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is3D = hallDto.Is3D,
                    Is4Dx = hallDto.Is4Dx
                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                listOfHalls.Add(hall);
                var projectionType = string.Empty;

                if (hall.Is4Dx)
                {
                    projectionType = hall.Is3D ? "4Dx/3D" : "4Dx";
                }
                else if (hall.Is3D)
                {
                    projectionType = "3D";
                }
                else
                {
                    projectionType = "Normal";
                }

                sb.AppendLine(String.Format(SuccessfulImportHallSeat, hall.Name, projectionType, hall.Seats.Count));
            }

            context.Halls.AddRange(listOfHalls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionsXmlDto[]), new XmlRootAttribute("Projections"));

            var sb = new StringBuilder();

            using (var stringReader = new StringReader(xmlString))
            {
                var xmlDtos = (ImportProjectionsXmlDto[])xmlSerializer.Deserialize(stringReader);

                var listOfValidProjections = new List<Projection>();

                foreach (var projDto in xmlDtos)
                {
                    var movie = context.Movies.FirstOrDefault(x => x.Id == projDto.MovieId);
                    var hall = context.Halls.FirstOrDefault(x => x.Id == projDto.HallId);

                    if (movie == null || hall == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var projection = new Projection
                    {
                        MovieId = movie.Id,
                        HallId = hall.Id,
                        DateTime = DateTime.ParseExact(projDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                    };

                    listOfValidProjections.Add(projection);
                    sb.AppendLine(string.Format(SuccessfulImportProjection, movie.Title, projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
                }

                context.Projections.AddRange(listOfValidProjections);
                context.SaveChanges();
                return sb.ToString().Trim();
            }


        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(XMLImportCustomersTIcketsDto[]), new XmlRootAttribute("Customers"));
            var sb = new StringBuilder();

            using (var stringReader = new StringReader(xmlString))
            {
                var xmlDtos = (XMLImportCustomersTIcketsDto[])xmlSerializer.Deserialize(stringReader);

                foreach (var custDto in xmlDtos)
                {
                    if (!IsValid(custDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var customer = new Customer
                    {
                        FirstName = custDto.FirstName,
                        LastName = custDto.LastName,
                        Age = custDto.Age,
                        Balance = custDto.Balance
                    };

                    context.Customers.Add(customer);
                    context.SaveChanges();

                    var tickets = custDto.Tickets
                .Where(x => IsValid(x) && context.Projections.Any(y => y.Id == x.ProjectionId))
                .Select(x => new Ticket
                {
                    CustomerId = customer.Id,
                    ProjectionId = x.ProjectionId,
                    Price = x.Price
                }).ToList();

                    context.Tickets.AddRange(tickets);
                    context.SaveChanges();

                    sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, tickets.Count()));
                }

                return sb.ToString().Trim();
            }
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}