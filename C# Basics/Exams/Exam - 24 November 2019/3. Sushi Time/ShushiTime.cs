using System;

namespace Exam24November2019
{
    class Program
    {
        static void Main()
        {
            string sushiType = Console.ReadLine();
            string restaurantName = Console.ReadLine();
            int portionQy = int.Parse(Console.ReadLine());
            char delivery = char.Parse(Console.ReadLine());
            double price = 0;

            double sashimiSushiZone = 4.99;
            double makeSushiZone = 5.29;
            double uramakiSushiZone = 5.99;
            double temakiSushiZone = 4.29;

            double sashimiSushiTime = 5.49;
            double makeSushiTime = 4.69;
            double uramakiSushiTime = 4.49;
            double temakiSushiTime = 5.19;

            double sashimiSushiBar = 5.25;
            double makeSushiBar = 5.55;
            double uramakiSushiBar = 6.25;
            double temakiSushiBar = 4.75;

            double sashimiAsianPub = 4.50;
            double makeAsianPub = 4.80;
            double uramakiAsianPub = 5.50;
            double temakiAsianPub = 5.50;

            if (restaurantName != "Sushi Zone" && restaurantName != "Sushi Time" && restaurantName != "Sushi Bar" && restaurantName != "Asian Pub")
            {
                Console.WriteLine($"{restaurantName} is invalid restaurant!");
                return;
            }
            else if (restaurantName == "Sushi Zone")
            {
                if (sushiType == "sashimi")
                {
                    price = portionQy * sashimiSushiZone;
                }
                else if (sushiType == "maki")
                {
                    price = portionQy * makeSushiZone;
                }
                else if (sushiType == "uramaki")
                {
                    price = portionQy * uramakiSushiZone;
                }
                else if (sushiType == "temaki")
                {
                    price = portionQy * temakiSushiZone;
                }
            }
            else if (restaurantName == "Sushi Time")
            {
                if (sushiType == "sashimi")
                {
                    price = portionQy * sashimiSushiTime;
                }
                else if (sushiType == "maki")
                {
                    price = portionQy * makeSushiTime;
                }
                else if (sushiType == "uramaki")
                {
                    price = portionQy * uramakiSushiTime;
                }
                else if (sushiType == "temaki")
                {
                    price = portionQy * temakiSushiTime;
                }
            }
            else if (restaurantName == "Sushi Bar")
            {
                if (sushiType == "sashimi")
                {
                    price = portionQy * sashimiSushiBar;
                }
                else if (sushiType == "maki")
                {
                    price = portionQy * makeSushiBar;
                }
                else if (sushiType == "uramaki")
                {
                    price = portionQy * uramakiSushiBar;
                }
                else if (sushiType == "temaki")
                {
                    price = portionQy * temakiSushiBar;
                }
            }
            else if (restaurantName == "Asian Pub")
            {

                if (sushiType == "sashimi")
                {
                    price = portionQy * sashimiAsianPub;
                }
                else if (sushiType == "maki")
                {
                    price = portionQy * makeAsianPub;
                }
                else if (sushiType == "uramaki")
                {
                    price = portionQy * uramakiAsianPub;
                }
                else if (sushiType == "temaki")
                {
                    price = portionQy * temakiAsianPub;
                }
            }

            if (delivery == 'Y')
            {
                price *= 1.2;
            }

            Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
        }
    }
}