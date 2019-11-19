using System;

namespace AdvertisementMessage
{
    class Program
    {
        static void Main()
        {
            string[] phrases = { "Excellent product", "Such a great product", "I always use that product", "Best product of its category", "Exceptional product", "I can’t live without this product" };
            string[] events = { "Now I feel good", "I have succeeded with this product", "Makes miracles. I am happy of theresults", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int countOfMessages = int.Parse(Console.ReadLine());
            Random rnd = new Random();

            for (int i = 1; i <= countOfMessages; i++)
            {
                string phrase = phrases[rnd.Next(0, phrases.Length - 1)];
                string currentEvent = events[rnd.Next(0, events.Length - 1)];
                string author = authors[rnd.Next(0, authors.Length - 1)];
                string city = cities[rnd.Next(0, cities.Length - 1)];

                Console.WriteLine($"{phrase} {currentEvent} {author} - {city}");
            }
        }
    }
}