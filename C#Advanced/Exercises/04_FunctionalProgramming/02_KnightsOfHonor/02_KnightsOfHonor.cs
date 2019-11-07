using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main()
        {
            Func<string, string> names = x => "Sir " + x;
            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(names)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}