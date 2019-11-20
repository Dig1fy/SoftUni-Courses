using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());

            var dataBase = new Dictionary<string, string>();
            dataBase = dataBase.ToDictionary(x => x.Key, x => x.Value);

            for (int i = 1; i <= num; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                string action = command[0];
                var person = command[1];

                if (action == "register")
                {
                    var registration = command[2];

                    if (!dataBase.ContainsKey(person))
                    {
                        dataBase[person] = registration;
                        Console.WriteLine($"{person} registered {registration} successfully");
                    }
                    else
                    {
                        string plate = string.Empty;

                        foreach (var kvp in dataBase)
                        {
                            if (kvp.Key == person)
                            {
                                plate = kvp.Value;
                            }
                        }
                        Console.WriteLine($"ERROR: already registered with plate number {plate}");
                    }
                }

                else if (action == "unregister")
                {
                    if (!dataBase.ContainsKey(person))
                    {
                        Console.WriteLine($"ERROR: user {person} not found");
                    }

                    else
                    {
                        dataBase.Remove(person);
                        Console.WriteLine($"{person} unregistered successfully");
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, dataBase.Select(x => $"{x.Key} => {x.Value}")));
        }
    }
}