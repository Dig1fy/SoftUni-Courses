using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsAndDictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfRows = int.Parse(Console.ReadLine());
            var uniqueElements = new HashSet<string>();

            for (int i = 0; i < numberOfRows; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    uniqueElements.Add(input[j]);
                }
            }

            uniqueElements = uniqueElements.OrderBy(x => x).ToHashSet();
            Console.WriteLine(string.Join(" ", uniqueElements));
        }
    }
}