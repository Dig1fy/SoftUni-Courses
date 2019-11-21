using System;

namespace DIstanceCalculator
{
    class Program
    {
        static void Main()
        {
            int stepsMade = int.Parse(Console.ReadLine());
            double lengthOfStep = double.Parse(Console.ReadLine());
            double distanceToTravel = double.Parse(Console.ReadLine()) * 100;
            int counter = 0;

            for (int i = 1; i <= stepsMade; i++)
            {
                if (i % 5 == 0)
                {
                    counter++;
                }
            }

            double shorterSteps = counter * lengthOfStep * 0.7; //28
            double restOfTheSteps = (stepsMade - counter) * lengthOfStep;

            double percentage = ((shorterSteps + restOfTheSteps) / distanceToTravel) * 100;
            Console.WriteLine($"You travelled {percentage:f2}% of the distance!");
        }
    }
}