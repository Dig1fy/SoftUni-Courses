using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main()
        {
            var inputNumbers = int.Parse(Console.ReadLine());
            var sequenceOfNames = Console.ReadLine()
                .Split()
                .ToList();

            Predicate<string> removeLongerNames = x => x.Length > inputNumbers;
            sequenceOfNames.RemoveAll(removeLongerNames);

            Console.WriteLine(string.Join(Environment.NewLine, sequenceOfNames));
        }
    }
}