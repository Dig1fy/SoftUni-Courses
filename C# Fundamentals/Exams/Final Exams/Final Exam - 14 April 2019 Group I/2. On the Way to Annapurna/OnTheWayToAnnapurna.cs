using System;
using System.Collections.Generic;
using System.Linq;

namespace OnTheWayToAnnapurna
{
    class Program
    {
        static void Main()
        {
            var command = string.Empty;
            var listOfItems = new Dictionary<string, List<string>>();

            while ((command = Console.ReadLine()) != "END")
            {
                string[] separator = { "->", "," };
                var input = command
                    .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                var action = input[0];

                if (action == "Add" && input.Count == 3)
                {
                    var store = input[1];
                    var item = input[2];

                    if (!listOfItems.ContainsKey(store))
                    {
                        listOfItems.Add(store, new List<string>());
                    }

                    listOfItems[store].Add(item);
                }

                else if (action == "Add" && input.Count > 3)
                {
                    var store = input[1];

                    if (!listOfItems.ContainsKey(store))
                    {
                        listOfItems.Add(store, new List<string>());
                    }

                    for (int i = 2; i < input.Count; i++)
                    {
                        listOfItems[store].Add(input[i]);
                    }
                }

                else if (action == "Remove")
                {
                    var store = input[1];

                    if (listOfItems.ContainsKey(store))
                    {
                        listOfItems.Remove(store);
                    }
                }
            }

            Console.WriteLine("Stores list:");

            foreach (var store in listOfItems.OrderByDescending(x => x.Value.Count()).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{store.Key}");

                foreach (var item in store.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }
        }
    }
}
