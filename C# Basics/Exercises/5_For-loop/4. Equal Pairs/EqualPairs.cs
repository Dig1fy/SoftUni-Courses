using System;

namespace ForLoop
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int diff = 0;
            int lastSum = 0;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int numberOne = int.Parse(Console.ReadLine());
                int numberTwo = int.Parse(Console.ReadLine());
                sum = numberOne + numberTwo;

                if (i > 0)
                {
                    diff = Math.Abs(lastSum - sum);

                }

                lastSum = sum;
            }

            if (diff == 0)
            {
                Console.WriteLine($"Yes, value={sum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={diff}");
            }
        }
    }
}