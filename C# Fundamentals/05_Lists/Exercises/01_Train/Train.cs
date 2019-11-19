using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = string.Empty;
            int capacity = int.Parse(Console.ReadLine());

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArray = command.Split().ToArray();

                if (commandArray.Length == 2)
                {
                    wagons.Add(int.Parse(commandArray[1]));

                }

                else if (commandArray.Length == 1)
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + int.Parse(commandArray[0]) <= capacity)
                        {
                            wagons.Insert(i, wagons[i] + int.Parse(commandArray[0]));
                            wagons.RemoveAt(i + 1);
                            break;

                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}