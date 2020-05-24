using System;

namespace NestedConditionalStatements
{
    class Program
    {
        static void Main()
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishmenCount = int.Parse(Console.ReadLine());

            double springPrice = 3000;
            double summerAndAutumnPrice = 4200;
            double winterPrice = 2600;
            double price = 0;

            if (season == "Spring")
            {
                if (fishmenCount <= 6)
                {
                    price = springPrice * 0.9;
                }
                else if (fishmenCount > 6 && fishmenCount <= 11)
                {
                    price = springPrice * 0.85;
                }
                else if (fishmenCount >= 12)
                {
                    price = springPrice * 0.75;
                }
            }
            else if (season == "Summer" || season == "Autumn")
            {
                if (fishmenCount <= 6)
                {
                    price = summerAndAutumnPrice * 0.9;
                }
                else if (fishmenCount > 6 && fishmenCount <= 11)
                {
                    price = summerAndAutumnPrice * 0.85;
                }
                else if (fishmenCount >= 12)
                {
                    price = summerAndAutumnPrice * 0.75;
                }
            }
            else if (season == "Winter")
            {
                if (fishmenCount <= 6)
                {
                    price = winterPrice * 0.9;
                }
                else if (fishmenCount > 6 && fishmenCount <= 11)
                {
                    price = winterPrice * 0.85;
                }
                else if (fishmenCount >= 12)
                {
                    price = winterPrice * 0.75;
                }
            }

            if (fishmenCount % 2 == 0 && (season == "Spring" || season == "Winter" || season == "Summer"))
            {
                price = price * 0.95;
            }

            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {(budget - price):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(budget - price):f2} leva.");
            }
        }
    }
}