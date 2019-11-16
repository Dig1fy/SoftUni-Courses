using System;

namespace EnglishNameOfTheLastDigit
{
    class Program
    {
        static void Main()
        {
            double initialMoney = double.Parse(Console.ReadLine());
            double outFall4 = 39.99;
            double csOg = 15.99;
            double zplinterZell = 19.99;
            double honored2 = 59.99;
            double roverWatch = 29.99;
            double roverWatchOriginEdition = 39.99;
            double currentPrice = 0;
            bool outOfMoney = false;
            double remaining = initialMoney;

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Game Time")
            {
                switch (command)
                {
                    case "OutFall 4": currentPrice = outFall4; break;
                    case "CS: OG": currentPrice = csOg; break;
                    case "Zplinter Zell": currentPrice = zplinterZell; break;
                    case "Honored 2": currentPrice = honored2; break;
                    case "RoverWatch": currentPrice = roverWatch; break;
                    case "RoverWatch Origins Edition": currentPrice = roverWatchOriginEdition; break;

                    default:
                        Console.WriteLine("Not Found");
                        continue;
                }

                if (remaining - currentPrice < 0)
                {
                    Console.WriteLine("Too Expensive");
                    continue;
                }
                else if (remaining - currentPrice >= 0)
                {
                    remaining -= currentPrice;

                    Console.WriteLine($"Bought {command}");
                    if (remaining == 0)
                    {
                        Console.WriteLine("Out of money!");
                        outOfMoney = true;
                        break;
                    }
                }
            }

            if (!outOfMoney)
            {
                Console.WriteLine($"Total spent: ${initialMoney - remaining:f2}. Remaining: ${remaining:f2}");
            }
        }
    }
}