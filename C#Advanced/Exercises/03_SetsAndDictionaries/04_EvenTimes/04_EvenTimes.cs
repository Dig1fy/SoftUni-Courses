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
            var listOfNumbers = new Dictionary<int, int>();

            for (int i = 0; i < numberOfRows; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());

                if (!listOfNumbers.ContainsKey(currentNumber))
                {
                    listOfNumbers.Add(currentNumber, 0);
                }

                listOfNumbers[currentNumber]++;
            }

            foreach (var num in listOfNumbers)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                }
            }
        }
    }
}