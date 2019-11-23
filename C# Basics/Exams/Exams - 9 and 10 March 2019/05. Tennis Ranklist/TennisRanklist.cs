using System;

namespace ExamOn09And10March2019
{
    class Program
    {
        static void Main()
        {
            int tournamentNum = int.Parse(Console.ReadLine());
            int initialPoints = int.Parse(Console.ReadLine());
            string stage = "";

            int Win = 2000;
            int Final = 1200;
            int semiFinal = 720;
            int counter = 1;
            int pointsTotal = initialPoints;
            int pointsWon = 0;

            double percentage = 0;
            int winsCount = 0;

            while (counter <= tournamentNum)
            {
                stage = Console.ReadLine();

                if (stage == "W")
                {
                    pointsTotal += Win;
                    winsCount++;
                }
                else if (stage == "F")
                {
                    pointsTotal += Final;
                }
                else if (stage == "SF")
                {
                    pointsTotal += semiFinal;
                }

                ++counter;
            }

            percentage = ((double)winsCount / (double)tournamentNum) * 100;
            pointsWon = pointsTotal - initialPoints;
            double averagePoints = pointsWon / tournamentNum;

            Console.WriteLine($"Final points: {pointsTotal}");
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{percentage:f2}%");
        }
    }
}