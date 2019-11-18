using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main()
        {
            int[] lineOfNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int desiredSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < lineOfNumbers.Length; i++)
            {
                for (int k = i + 1; k < lineOfNumbers.Length; k++)
                {
                    if (lineOfNumbers[i] + lineOfNumbers[k] == desiredSum)
                    {
                        Console.Write($"{lineOfNumbers[i]} {lineOfNumbers[k]}");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}