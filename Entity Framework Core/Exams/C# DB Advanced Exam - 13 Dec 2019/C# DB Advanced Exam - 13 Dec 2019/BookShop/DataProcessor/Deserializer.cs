namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportBookDto[]), new XmlRootAttribute("Books"));
            StringBuilder stringBuilder = new StringBuilder();

            using (StringReader stringReader = new StringReader(xmlString))
            {
                ImportBookDto[] importBookDtos = (ImportBookDto[])xmlSerializer.Deserialize(stringReader);

                List<Book> listOfValidBooks = new List<Book>();

                foreach (var bookDto in importBookDtos)
                {
                    //It takes all the attributes of the properties and check if they're valid (maxLength, Range, Required etc.)
                    if (!IsValid(bookDto))
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    //We need to explicitly check if the PublishedOn(Date coming as string) is valid.
                    DateTime publishedOnTemp;
                    bool isDateValid = DateTime.TryParseExact(bookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out publishedOnTemp);

                    if (!isDateValid)
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    //Now we know that all the input is valid so we can import the data

                    Book validBook = new Book
                    {
                        Name = bookDto.Name,
                        //Cast the enumeration
                        Genre = (Genre)bookDto.Genre,
                        Pages = bookDto.Pages,
                        Price = bookDto.Price,
                        PublishedOn = publishedOnTemp
                    };

                    listOfValidBooks.Add(validBook);

                    stringBuilder.AppendLine(String.Format(SuccessfullyImportedBook, validBook.Name, validBook.Price));
                }

                context.Books.AddRange(listOfValidBooks);
                context.SaveChanges();

                return stringBuilder.ToString().Trim();
            }
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder stringBuilder = new StringBuilder();

            ImportAuthorDto[] authorDtos = JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString);

            //we create list of authors and validate the email before inport the data to the db
            List<Author> listOfAuthors = new List<Author>();

            foreach (var AuthorDto in authorDtos)
            {
                if (!IsValid(AuthorDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                if (listOfAuthors.Any(x => x.Email == AuthorDto.Email))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                //If we pass the first two validations, we can create an Author
                Author author = new Author
                {
                  FirstName = AuthorDto.FirstName,
                  LastName = AuthorDto.LastName,
                    Email = AuthorDto.Email,
                    Phone = AuthorDto.Phone
                };

                foreach (var bookDto in AuthorDto.Books)
                {
                    if (!bookDto.Id.HasValue)
                    {
                        continue;
                    }

                    //We check if there is already a book with this ID in the db
                    Book book = context.Books.FirstOrDefault(b => b.Id == bookDto.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    //If we pass the validations and there is valid book, we add it to the Author (it's many-to-many relationship)
                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book
                    });
                }

                //if the author has no books, we return error message

                if (author.AuthorsBooks.Count == 0)
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                //Else, we have valid books and valid author, so we add them to the DB
                listOfAuthors.Add(author);

                stringBuilder.AppendLine(String.Format(SuccessfullyImportedAuthor, author.FirstName + " " + author.LastName, author.AuthorsBooks.Count));
            }

            //Finally, we add all the valid authors. EF will automatically add the mapped books to each author.
            context.Authors.AddRange(listOfAuthors);
            context.SaveChanges();

            return stringBuilder.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}