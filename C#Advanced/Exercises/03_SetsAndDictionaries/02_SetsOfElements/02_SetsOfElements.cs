using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsAndDictionaries
{
    class Program
    {
        static void Main(string[] args)
        {

            var sizeOfSets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var firstSetSize = sizeOfSets[0];
            var secondSetSize = sizeOfSets[1];

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int first = 0; first < firstSetSize; first++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int second = 0; second < secondSetSize; second++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            var result = firstSet.Intersect(secondSet).ToArray();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}