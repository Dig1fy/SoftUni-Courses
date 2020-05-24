using System;

namespace ConditionalStatements
{
    class Program
    {
        static void Main()
        {
            double inputNumber = double.Parse(Console.ReadLine());
            string inputMetric = Console.ReadLine();
            string outputMetric = Console.ReadLine();
                       
            if (inputMetric == "cm")
            {
                inputNumber /= 100;
            }
            else if (inputMetric == "mm")
            {
                inputNumber /= 1000;
            }

            if (outputMetric == "cm")
            {
                inputNumber *= 100;
            }
            else if (outputMetric == "mm")
            {
                inputNumber *= 1000;
            }

            Console.WriteLine($"{inputNumber:F3}");
        }
    }
}