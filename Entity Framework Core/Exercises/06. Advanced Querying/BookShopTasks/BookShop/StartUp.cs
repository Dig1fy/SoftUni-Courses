namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        /*
         *  NOTE:   Using the syntax with Environment.NewLine breaks the Judge zero tests for output length.
         *  Anyway, it gives 100/100 + shorter and clearer code...totally worth it!
         */
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);


            //----------------- Task 1 - Age Restriction -----------------

            //string command = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db, command));



            // ----------------- Task 2 - Golden Books -----------------
            //Console.WriteLine(GetGoldenBooks(db));

            // ----------------- Task 3 - Books by Price -----------------
            //Console.WriteLine(GetBooksByPrice(db));

            // ----------------- Task 4 - Not Released In -----------------
            //var year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db, year));

            // ----------------- Task 5 - Book Titles by Category -----------------
            //var input = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(db, input));

            // ----------------- Task 6 - Released Before Date -----------------
            //var inputDate = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(db, inputDate));

            // ----------------- Task 7 - Author Search -----------------
            //var input = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

            // ----------------- Task 8 - Book Search -----------------
            //var input = Console.ReadLine();
            //Console.WriteLine(GetBookTitlesContaining(db, input));

            // ----------------- Task 9 - Book Search by Author -----------------
            //var input = Console.ReadLine();
            //Console.WriteLine(GetBooksByAuthor(db, input));

            // ----------------- Task 11 - Total Book Copies -----------------
            //Console.WriteLine(CountCopiesByAuthor(db));

            // ----------------- Task 12 - Profit by Category -----------------
            //Console.WriteLine(GetTotalProfitByCategory(db));

            // ----------------- Task 13 - Most Recent Books -----------------
            //Console.WriteLine(GetMostRecentBooks(db));

            // ----------------- Task 14 - Increase Prices -----------------
            //IncreasePrices(db);

            // ----------------- Task 15 - Remove Books -----------------
            //Console.WriteLine(RemoveBooks(db));
        }



        //    ----------------- Task 1 - Age Restriction -----------------

        /*public static string GetBooksByAgeRestriction(BookShopContext db, string command)
        {
            var books = db.Books
                .AsEnumerable()
                .Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => b.Title)
                                    .OrderBy(b => b)
                                    .ToList();

            return string.Join(Environment.NewLine, books);            
        */

        //    ----------------- Task 2 - Golden Books -----------------
        /*public static string GetGoldenBooks(BookShopContext context)
        {
            var bookTitles = context
                  .Books
                  .AsEnumerable()
                  .Where(x => x.EditionType.ToString() == "Gold" && x.Copies < 5000)
                  .OrderBy(x => x.BookId)
                  .Select(x=>x.Title)
                  .ToList();

            return string.Join(Environment.NewLine, bookTitles);
        }*/

        //----------------- Task 3 - Books by Price -----------------
        /*public static string GetBooksByPrice(BookShopContext context)
        {
            var desiredBooks = context
                .Books.Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in desiredBooks)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }*/

        // ----------------- Task 4 - Not Released In -----------------
        /*public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var desiredBooks = context
                .Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            return string.Join(Environment.NewLine, desiredBooks).Trim();
        }
        */

        // ----------------- Task 5 - Book Titles by Category -----------------
        /*public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var listOfCategories = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var resultList = new List<string>();

            foreach (var cat in listOfCategories)
            {
                var desiredBooks = context
                    .Books
                    .Where(x => x.BookCategories.Any(x => x.Category.Name.ToLower().Equals(cat.ToLower())))
                .Select(x =>  x.Title )
                .ToList();

                resultList.AddRange(desiredBooks);
            }

            return string.Join(Environment.NewLine, resultList.OrderBy(x => x));
        }
        */

        // ----------------- Task 6 - Released Before Date -----------------
        /*public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var desiredBooks = context
                .Books
                .Where(x => x.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.CurrentCulture))
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new
                {
                    Title = x.Title,
                    EditionType = x.EditionType.ToString(),
                    Price = x.Price
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in desiredBooks)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }
        */

        // ----------------- Task 7 - Author Search -----------------
        /*public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context
                .Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName
                })
                .OrderBy(x => x.FullName)
                .ToList();

            return string.Join(Environment.NewLine, authors.Select(x=>x.FullName));
        }
        */

        // ----------------- Task 8 - Book Search -----------------
        /* public static string GetBookTitlesContaining(BookShopContext context, string input)
         {
             var desiredBooks = context
                 .Books
                 .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                 .OrderBy(x => x.Title)
                 .Select(x => x.Title)
                 .ToArray();

             return string.Join(Environment.NewLine, desiredBooks);
         }
        */

        // ----------------- Task 9 - Book Search by Author -----------------
        /*public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var bookAuthor = context
                .Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => new
                {
                    Title = x.Title,
                    Author = x.Author.FirstName + " " + x.Author.LastName,
                    BookId = x.BookId
                })
                .OrderBy(x => x.BookId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var b in bookAuthor)
            {
                sb.AppendLine($"{b.Title} ({b.Author})");
            }

            return sb.ToString().Trim();
        }
        */

        // ----------------- Task 10 - Count Books -----------------
        /*public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var numberOfBooks = context
                .Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return numberOfBooks;
        }
        */

        // ----------------- Task 11 - Total Book Copies -----------------
        /* public static string CountCopiesByAuthor(BookShopContext context)
        {
            var books =
                    context
                    .Authors
                    .Select(x => new
                    {
                        Author = x.FirstName + " " + x.LastName,
                        Copies = x.Books.Select(y => y.Copies).Sum()

                    })
                   .OrderByDescending(x => x.Copies);

            var sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Author} - {b.Copies}");
            }

            return sb.ToString().Trim();
        }
        */

        // ----------------- Task 12 - Profit by Category -----------------
        /* public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var books = context
                .Categories
                .Select(x => new
                {
                    Category = x.Name,
                    Profit = x.CategoryBooks.Select(x => x.Book.Price * x.Book.Copies).Sum()
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Category)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Category} ${b.Profit:f2}");
            }

            return sb.ToString().Trim();
        }
        */

        // ----------------- Task 13 - Most Recent Books -----------------
        /* public static string GetMostRecentBooks(BookShopContext context)
        {
            var topBooks = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    BooksYearAndTitle = c.CategoryBooks.Select(cb => new
                    {
                        BooksTitle = cb.Book.Title,
                        BooksYear = cb.Book.ReleaseDate
                    })
                      .OrderByDescending(x => x.BooksYear)
                      .Take(3)
                })
                .OrderBy(x => x.CategoryName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var c in topBooks)
            {
                sb.AppendLine($"--{c.CategoryName}");

                foreach (var b in c.BooksYearAndTitle)
                {
                    sb.AppendLine($"{b.BooksTitle} ({b.BooksYear.Value.Year})");
                }
            }

            return sb.ToString().Trim();
        }
        */

        // ----------------- Task 14 - Increase Prices -----------------
        /* public static void IncreasePrices(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }
        */

        // ----------------- Task 15 - Remove Books -----------------
        /* public static int RemoveBooks(BookShopContext context)
         {
             var booksToRemove = context
                 .Books
                 .Where(b => b.Copies < 4200);

             var deletedBooks = booksToRemove.Count();

             context.Books.RemoveRange(booksToRemove);

             context.SaveChanges();

             return deletedBooks;
         }
         */
    }
}
