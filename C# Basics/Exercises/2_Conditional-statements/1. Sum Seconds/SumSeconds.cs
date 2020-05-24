using System;

namespace ConditionalStatements
{
    class Program
    {
        static void Main()
        {
            int timeFirst = int.Parse(Console.ReadLine());
            int timeSecond = int.Parse(Console.ReadLine());
            int timeThird = int.Parse(Console.ReadLine());

            int totalTime = timeFirst + timeSecond + timeThird;
            int totalMinutes = totalTime / 60;
            int totalSeconds = totalTime % 60;

            if (totalSeconds < 10)
            {
                Console.WriteLine($"{totalMinutes}:0{totalSeconds}");
            }
            else
            {
                Console.WriteLine($"{totalMinutes}:{totalSeconds}");
            }
        }
    }
}