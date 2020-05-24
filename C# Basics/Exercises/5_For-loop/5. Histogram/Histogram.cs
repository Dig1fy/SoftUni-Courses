using System;

namespace ForLoop
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber < 200)
                {
                    p1++;
                }
                if (currentNumber >= 200 && currentNumber <= 399)
                {
                    p2++;
                }
                if (currentNumber >= 400 && currentNumber <= 599)
                {
                    p3++;
                }
                if (currentNumber >= 600 && currentNumber <= 799)
                {
                    p4++;
                }
                if (currentNumber >= 800)
                {
                    p5++;
                }
            }

            double p1Percentage = p1 / n * 100;
            double p2Percentage = p2 / n * 100;
            double p3Percentage = p3 / n * 100;
            double p4Percentage = p4 / n * 100;
            double p5Percentage = p5 / n * 100;

            Console.WriteLine($"{p1Percentage:f2}%");
            Console.WriteLine($"{p2Percentage:f2}%");
            Console.WriteLine($"{p3Percentage:f2}%");
            Console.WriteLine($"{p4Percentage:f2}%");
            Console.WriteLine($"{p5Percentage:f2}%");
        }
    }
}