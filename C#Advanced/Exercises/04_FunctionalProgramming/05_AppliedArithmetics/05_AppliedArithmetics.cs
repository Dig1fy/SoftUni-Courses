using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main()
        {
            var listOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Action<string> takeAction = operation =>
            {
                switch (operation)
                {
                    case "add":
                        listOfNumbers = listOfNumbers.Select(x => x + 1).ToArray();
                        break;

                    case "subtract":
                        listOfNumbers = listOfNumbers.Select(x => x - 1).ToArray();
                        break;

                    case "multiply":
                        listOfNumbers = listOfNumbers.Select(x => x * 2).ToArray();
                        break;

                    case "print":
                        Console.WriteLine(string.Join(" ", listOfNumbers));
                        break;

                    default:
                        break;
                }
            };

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                takeAction(command);
            }
        }
    }
}