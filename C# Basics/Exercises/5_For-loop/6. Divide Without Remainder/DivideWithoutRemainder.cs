using System;

namespace ForLoop
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            double r1 = 0;
            double r2 = 0;
            double r3 = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num % 2 == 0)
                {
                    r1++;
                }
                if (num % 3 == 0)
                {
                    r2++;
                }
                if (num % 4 == 0)
                {
                    r3++;
                }
            }

            double r1Perc = r1 / n * 100;
            double r2Perc = r2 / n * 100;
            double r3Perc = r3 / n * 100;

            Console.WriteLine($"{r1Perc:f2}%");
            Console.WriteLine($"{r2Perc:f2}%");
            Console.WriteLine($"{r3Perc:f2}%");
        }
    }
}