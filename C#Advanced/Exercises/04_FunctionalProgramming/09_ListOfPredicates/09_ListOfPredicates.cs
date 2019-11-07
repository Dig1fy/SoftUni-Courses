using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main()
        {
            var range = int.Parse(Console.ReadLine());
            var delimeters = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var builder = new StringBuilder();

            Func<int, List<int>> getListOfNumbers = GetListOfNumbers;
            Func<int, List<int>, bool> isDivisible = IsDivisible;
            var resultList = getListOfNumbers(range).ToList();

            foreach (var num in resultList)
            {
                if (IsDivisible(num, delimeters))
                {
                    builder.Append(num + " ");
                }
            }

            Console.WriteLine(string.Join(" ", builder));
        }

        private static bool IsDivisible(int divider, List<int> numbers)
        {
            var isTrue = true;

            foreach (var number in numbers)
            {
                if (divider % number == 0)
                {
                    continue;
                }
                else
                {
                    isTrue = false;
                    break;
                }
            }

            return isTrue;
        }

        private static List<int> GetListOfNumbers(int endNum)
        {
            var list = new List<int>();
            for (int i = 1; i <= endNum; i++)
            {
                list.Add(i);
            }

            return list;
        }
    }
}