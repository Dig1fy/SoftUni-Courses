using System;

namespace ExamOn20April2019
{
    class Program
    {
        static void Main()
        {
            int easterBreadCount = int.Parse(Console.ReadLine());
            string baker = string.Empty;
            string command = string.Empty;
            int ratingCounter = 0;
            int maxRating = 0;
            string bestBaker = string.Empty;
            bool bakerTrue = false;

            for (int i = 1; i <= easterBreadCount; i++)
            {
                baker = Console.ReadLine();

                while ((command = Console.ReadLine()) != "Stop")
                {
                    int ratingNum = int.Parse(command);
                    ratingCounter += ratingNum;

                    if (ratingCounter > maxRating)
                    {
                        bestBaker = baker;
                        bakerTrue = true;
                        maxRating = ratingCounter;
                    }
                }

                Console.WriteLine($"{baker} has {ratingCounter} points.");
                ratingCounter = 0;

                if (bakerTrue)
                {
                    Console.WriteLine($"{bestBaker} is the new number 1!");
                }

                bakerTrue = false;
            }

            Console.WriteLine($"{bestBaker} won competition with {maxRating} points!");
        }
    }
}