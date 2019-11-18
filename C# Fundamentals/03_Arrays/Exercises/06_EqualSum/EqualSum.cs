using System;
using System.Linq;

namespace EqualSum
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            if (numbers.Length == 1)
            {
                Console.WriteLine("0");
                return;
            }

            int leftSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i > 0)
                {
                    leftSum += numbers[i - 1];
                }

                int rightSum = 0;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    rightSum += numbers[j];
                }
                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine("no");
        }
    }
}