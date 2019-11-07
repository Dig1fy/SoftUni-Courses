using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Reverse()
                .Select(int.Parse)
                .ToList();

            var delimeter = int.Parse(Console.ReadLine());
            var result = new List<int>();

            Predicate<int> dividedBy = currentNum => currentNum % delimeter == 0;
            Action<int> addToNewList = x => result.Add(x);

            foreach (var num in input.Where(x => !dividedBy(x)))
            {
                addToNewList(num);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}