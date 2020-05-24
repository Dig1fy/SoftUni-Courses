using System;

namespace ForLoop
{
    class Program
    {
        static void Main()
        {
            int totalNumbers = int.Parse(Console.ReadLine());

            int maxNumber = int.MinValue;
            int counter = 0;

            for (int i = 1; i <= totalNumbers; i++)
            {
                int current = int.Parse(Console.ReadLine());
                counter += current;

                if (current > maxNumber)
                {
                    maxNumber = current;
                }
            }

            counter -= maxNumber;

            if (maxNumber == counter)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {maxNumber}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(maxNumber - counter)}");
            }
        }
    }
}