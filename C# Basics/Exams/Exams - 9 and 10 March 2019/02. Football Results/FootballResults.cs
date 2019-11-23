using System;

namespace ExamOn09And10March2019
{
    class Program
    {
        static void Main()
        {
            string firstMatch = Console.ReadLine();
            string secondMatch = Console.ReadLine();
            string thirdMatch = Console.ReadLine();

            int wins = 0;
            int loses = 0;
            int draws = 0;

            if (firstMatch[0] > firstMatch[2])
            {
                wins++;
            }
            if (secondMatch[0] > secondMatch[2])
            {
                wins++;
            }
            if (thirdMatch[0] > thirdMatch[2])
            {
                wins++;
            }
            if (firstMatch[0] < firstMatch[2])
            {
                loses++;
            }
            if (secondMatch[0] < secondMatch[2])
            {
                loses++;
            }
            if (thirdMatch[0] < thirdMatch[2])
            {
                loses++;
            }
            if (firstMatch[0] == firstMatch[2])
            {
                draws++;
            }
            if (secondMatch[0] == secondMatch[2])
            {
                draws++;
            }
            if (thirdMatch[0] == thirdMatch[2])
            {
                draws++;
            }

            Console.WriteLine($"Team won {wins} games.");
            Console.WriteLine($"Team lost {loses} games.");
            Console.WriteLine($"Drawn games: {draws}");
        }
    }
}