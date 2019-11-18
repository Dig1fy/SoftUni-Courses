using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int topInt = input[0];

            for (int i = 0; i < input.Length; i++)
            {
                if (i == input.Length - 1)
                {
                    Console.Write(input[input.Length - 1]);
                    break;
                }
                if (input[i] > input[i + 1])
                {
                    Console.Write(input[i] + " ");
                }
            }
        }
    }
}