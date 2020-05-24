using System;

namespace NestedConditionalStatements
{
    class Program
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double moneySpent = 0;
            string placeToRest = "";
            string destination = "";

            if (budget <= 100)
            {
                if (season == "summer")
                {
                    moneySpent = 0.3 * budget;
                }
                else if (season == "winter")
                {
                    moneySpent = 0.7 * budget;
                }
                destination = "Bulgaria";
            }

            else if (budget > 100 && budget <= 1000)
            {
                if (season == "summer")
                {
                    moneySpent = 0.4 * budget;
                }
                else if (season == "winter")
                {
                    moneySpent = 0.8 * budget;
                }
                destination = "Balkans";
            }
            else if (budget > 1000)
            {
                moneySpent = 0.9 * budget;
                destination = "Europe";
            }

            if (season == "summer" && (destination == "Bulgaria" || destination == "Balkans"))
            {
                placeToRest = "Camp";
            }
            else if (season == "winter" && (destination == "Bulgaria" || destination == "Balkans"))
            {
                placeToRest = "Hotel";
            }
            else if (destination == "Europe")
            {
                placeToRest = "Hotel";
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{placeToRest} - {moneySpent:f2}");
        }
    }
}