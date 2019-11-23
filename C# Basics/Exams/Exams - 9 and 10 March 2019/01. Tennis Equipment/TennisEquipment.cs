using System;

namespace ExamOn09And10March2019
{
    class Program
    {
        static void Main()
        {
            double tennisRacket = double.Parse(Console.ReadLine());
            int racketQy = int.Parse(Console.ReadLine());
            int shoesQy = int.Parse(Console.ReadLine());

            double oneShoesPart = tennisRacket / 6;

            double totalPriceShoes = oneShoesPart * shoesQy;
            double totalPriceRackets = tennisRacket * racketQy;
            double totalPriceAccessories = 0.2 * (totalPriceRackets + totalPriceShoes);
            double totalSum = totalPriceShoes + totalPriceRackets + totalPriceAccessories;

            double jokovicHasToPay = totalSum / 8;
            double sponsorsHaveToPay = totalSum - jokovicHasToPay;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(jokovicHasToPay)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(sponsorsHaveToPay)}");
        }
    }
}