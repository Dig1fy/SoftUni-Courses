using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main()
        {
            Action<string[]> printNames = current => Console.WriteLine(string.Join(Environment.NewLine, current));

            var input = Console.ReadLine()
                .Split();

            printNames(input);
        }
    }
}