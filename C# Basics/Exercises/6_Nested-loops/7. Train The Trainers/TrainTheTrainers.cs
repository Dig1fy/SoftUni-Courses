using System;

namespace NestedLoops
{
    class Program
    {
        static void Main()
        {
            int judgesCount = int.Parse(Console.ReadLine());
            double averageAll = 0;
            int count = 0;
            string presentation = string.Empty;

            while ((presentation = Console.ReadLine()) != "Finish")
            {
                double averageRaiting = 0;

                for (int i = 0; i < judgesCount; i++)
                {
                    double evaluation = double.Parse(Console.ReadLine());
                    count++;
                    averageAll += evaluation;
                    averageRaiting += evaluation;
                }

                Console.WriteLine($"{presentation} - {averageRaiting / judgesCount:f2}.");
            }

            Console.WriteLine($"Student's final assessment is {averageAll / count:f2}.");
        }
    }
}