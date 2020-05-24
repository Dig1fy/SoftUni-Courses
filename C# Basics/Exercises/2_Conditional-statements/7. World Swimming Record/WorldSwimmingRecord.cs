using System;

namespace ConditionalStatements
{
    class Program
    {
        static void Main()
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double time = double.Parse(Console.ReadLine());

            double distanceTime = distance * time;
            double resistance = Math.Floor(distance / 15) * 12.5;
            double totalTime = resistance + distanceTime;
            double timeDifference = Math.Abs(totalTime - worldRecord);

            if (worldRecord <= totalTime)
            {
                Console.WriteLine($"No, he failed! He was {timeDifference:F2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:F2} seconds.");
            }
        }
    }
}