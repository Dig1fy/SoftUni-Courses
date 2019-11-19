using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialList = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToList();

            string newString = string.Empty;

            for (int i = 0; i < initialList.Count; i++)
            {
                List<string> wantedList = initialList[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                for (int j = 0; j < wantedList.Count; j++)
                {
                    newString += wantedList[j] + " ";
                }
            }

            initialList = newString.Split().ToList();
            Console.WriteLine(string.Join(" ", initialList));
        }
    }
}