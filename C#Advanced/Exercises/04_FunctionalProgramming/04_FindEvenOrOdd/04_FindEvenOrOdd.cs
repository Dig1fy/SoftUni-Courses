using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main()
        {
            var inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var startNum = inputNumbers[0];
            var endNum = inputNumbers[1];
            var condition = Console.ReadLine();

            var listOfNumbers = PopulateList(startNum, endNum);

            Predicate<int> even = x => x % 2 == 0;
            Predicate<int> odd = y => y % 2 != 0;

            if (condition == "odd")
            {
                listOfNumbers = listOfNumbers.FindAll(odd);
            }

            else
            {
                listOfNumbers = listOfNumbers.FindAll(even);
            }

            Console.WriteLine(string.Join(" ", listOfNumbers));
        }

        private static List<int> PopulateList(int startNum, int endNum)
        {
            var list = new List<int>();

            for (int i = startNum; i <= endNum; i++)
            {
                list.Add(i);
            }

            return list;
        }
    }
}