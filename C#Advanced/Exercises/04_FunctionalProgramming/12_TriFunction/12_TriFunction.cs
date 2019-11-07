using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var minSize = long.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split("\t\r\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, long, bool> isEqualOrBigger = (name, sumOfChars) =>
            {
                var currentSum = 0;
                foreach (var charR in name)
                {
                    currentSum += (int)charR;
                }
                return currentSum >= sumOfChars;
            };

            names = names.Where(x => isEqualOrBigger(x, minSize)).ToList();

            if (names.Count > 0) Console.WriteLine(names[0]);

        }
    }
}