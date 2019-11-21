using System;

namespace EasterCozonacs
{
    class Program
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            double floorPriceKG = double.Parse(Console.ReadLine());
            double eggsPriceKG = 0.75 * floorPriceKG;
            double milk250ml = (1.25 * floorPriceKG) / 4;

            double cozonacPrice = floorPriceKG + eggsPriceKG + milk250ml;
            int cozonacCounter = 0;
            int eggsCount = 0;

            while (budget >= cozonacPrice)
            {
                cozonacCounter++;
                eggsCount += 3;
                budget -= cozonacPrice;

                if (cozonacCounter % 3 == 0)
                {
                    eggsCount -= (cozonacCounter - 2);
                }
            }

            Console.WriteLine($"You made {cozonacCounter} cozonacs! Now you have {eggsCount} eggs and {budget:f2}BGN left.");
        }
    }
}
