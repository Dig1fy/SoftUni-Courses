using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 1; i <= numberOfCommands; i++)
            {
                string[] commandToArray = Console.ReadLine()
                    .Split()
                    .ToArray();

                if (commandToArray[2] == "going!")
                {
                    bool check = guests.Contains(commandToArray[0]);

                    if (check)
                    {
                        Console.WriteLine($"{commandToArray[0]} is already in the list!");
                    }
                    else
                    {
                        guests.Add(commandToArray[0]);
                    }
                }

                else if (commandToArray[2] == "not")
                {
                    bool check = guests.Contains(commandToArray[0]);

                    if (!check)
                    {
                        Console.WriteLine($"{commandToArray[0]} is not in the list!");
                    }
                    else
                    {
                        guests.Remove(commandToArray[0]);
                    }
                }
            }

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}