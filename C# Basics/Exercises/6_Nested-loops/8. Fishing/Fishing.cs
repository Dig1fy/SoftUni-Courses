using System;

namespace NestedLoops
{
    class Program
    {
        static void Main()
        {
            int dailyQuota = int.Parse(Console.ReadLine());
            int sumOfLetters = 0;
            string fishName = string.Empty;
            double fishProfit = 0;
            double fishLost = 0;
            bool stop = false;
            bool quota = false;
            int fishCount = 0;
            int fishCounter = 0;

            for (int i = 1; i <= dailyQuota; i++)
            {
                if (quota || stop)
                {
                    break;
                }

                fishName = Console.ReadLine();

                if (fishName == "Stop")
                {
                    stop = true;
                    break;
                }

                fishCounter++;
                double fishKilos = double.Parse(Console.ReadLine());
                fishCount = i;

                if (i == dailyQuota)
                {
                    quota = true;
                }

                sumOfLetters = 0;

                for (int j = 0; j <= fishName.Length - 1; j++)
                {
                    sumOfLetters += fishName[j];
                }

                if (fishCounter == 3)
                {
                    fishProfit += sumOfLetters / fishKilos;
                    fishCounter = 0;
                }
                else
                {
                    fishLost += sumOfLetters / fishKilos;
                }
            }

            if (quota)
            {
                Console.WriteLine("Lyubo fulfilled the quota!");
            }
            if (fishProfit >= fishLost)
            {
                Console.WriteLine($"Lyubo's profit from {fishCount} fishes is {(fishProfit - fishLost):f2} leva.");
            }
            else if (fishProfit < fishLost)
            {
                Console.WriteLine($"Lyubo lost {(fishLost - fishProfit):f2} leva today.");
            }
        }
    }
}