using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> numbers = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArray = command.Split().ToArray();
                string action = commandArray[0];
                int element = int.Parse(commandArray[1]);

                if (action == "Delete")
                {
                    numbers.RemoveAll(n => n == element);
                }

                else if (action == "Insert")
                {
                    int index = int.Parse(commandArray[2]);
                    numbers.Insert(index, element);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}