using System;

namespace RageExpenses
{
    class Program
    {
        static void Main()
        {
            double lostGames = double.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double headsetCounter = 0;
            double mouseCounter = 0;
            double keyboardCounter = 0;
            double displayCounter = 0;
            double totalKeyboards = 0;

            for (double i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    headsetCounter++;
                }
                if (i % 3 == 0)
                {
                    mouseCounter++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    keyboardCounter++;
                    totalKeyboards++;
                }
                if (keyboardCounter % 2 == 0 && keyboardCounter != 0)
                {
                    displayCounter++;

                }
                if (keyboardCounter == 2)
                {
                    keyboardCounter = 0;
                }
            }

            double totalDamageCosts = headsetCounter * headsetPrice + mouseCounter * mousePrice +
                totalKeyboards * keyboardPrice + displayCounter * displayPrice;

            Console.WriteLine($"Rage expenses: {totalDamageCosts:f2} lv.");
        }
    }
}