using System;

namespace ExamOn09And10March2019
{
    class Program
    {
        static void Main()
        {
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            int secondsPer100Meters = int.Parse(Console.ReadLine());

            int run = minutes * 60 + seconds;
            double decresingTime = distanceInMeters / 120;
            double totalDecreasedTime = decresingTime * 2.5;
            double totalTime = (distanceInMeters / 100) * secondsPer100Meters - totalDecreasedTime;

            if (totalTime <= run)
            {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine("His time is {0:F3}.", totalTime);
            }
            else if (totalTime > run)
            {
                double result = totalTime - run;
                Console.WriteLine("No, Marin failed! He was {0:F3} second slower.", result);
            }   
        }
    }
}