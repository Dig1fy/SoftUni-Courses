using System;
using System.Collections.Generic;

namespace SetsAndDictionaries
{
    class Program
    {
        static void Main(string[] args)
        {

            var numberOfnames = int.Parse(Console.ReadLine());
            var uniqueNames = new HashSet<string>();

            for (int i = 0; i < numberOfnames; i++)
            {
                uniqueNames.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, uniqueNames));
        }
    }
}