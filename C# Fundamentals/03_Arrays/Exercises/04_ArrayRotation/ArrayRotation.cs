using System;
using System.Linq;

namespace ArrayRotation
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                int lastElement = numbers[0];

                for (int k = 0; k < numbers.Length - 1; k++)
                {
                    numbers[k] = numbers[k + 1];
                }

                numbers[numbers.Length - 1] = lastElement;
            }

            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}