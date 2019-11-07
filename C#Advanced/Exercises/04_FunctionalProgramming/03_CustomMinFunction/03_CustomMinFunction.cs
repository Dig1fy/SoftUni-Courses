using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main()
        {
            Func<int[], int> minNumber = x => x.Min();

            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var result = minNumber(input);

            Console.WriteLine(result);
        }
    }
}