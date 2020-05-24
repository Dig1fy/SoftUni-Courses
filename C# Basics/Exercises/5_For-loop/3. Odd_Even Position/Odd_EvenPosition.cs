using System;

namespace ForLoop
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            double evenSum = 0;
            double evenMax = int.MinValue;
            double evenMin = int.MaxValue;

            double oddSum = 0;
            double oddMax = int.MinValue;
            double oddMin = int.MaxValue;
            double num2 = 0;

            for (int i = 1; i <= num; i++)
            {
                num2 = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += num2;
                    if (num2 > evenMax)
                    {
                        evenMax = num2;
                    }
                    if (num2 < evenMin)
                    {
                        evenMin = num2;
                    }

                }
                else
                {
                    oddSum += num2;
                    if (num2 > oddMax)
                    {
                        oddMax = num2;
                    }
                    if (num2 < oddMin)
                    {
                        oddMin = num2;
                    }
                }
            }

            Console.WriteLine($"OddSum={oddSum:F2},");

            if (oddMin != int.MaxValue)
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
            }
            else if (oddMin == int.MaxValue)
            {
                Console.WriteLine("OddMin=No,");
            }

            if (oddMax != int.MinValue)
            {
                Console.WriteLine($"OddMax={oddMax:f2},");
            }
            else
            {
                Console.WriteLine("OddMax=No,");
            }

            Console.WriteLine($"EvenSum={evenSum:f2},");

            if (evenMin == int.MaxValue)
            {
                Console.WriteLine("EvenMin=No,");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
            }

            if (evenMax == int.MinValue)
            {
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
        }
    }
}