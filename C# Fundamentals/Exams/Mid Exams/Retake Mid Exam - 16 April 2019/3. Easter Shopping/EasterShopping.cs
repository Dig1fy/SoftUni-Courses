using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterShopping
{
    class Program
    {
        static void Main()
        {
            List<string> shops = Console.ReadLine()
                .Split()
                .ToList();
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                string[] command = Console.ReadLine()
                    .Split()
                    .ToArray();
                string action = command[0];

                if (action == "Include")
                {
                    shops.Add(command[1]);
                }
                else if (action == "Visit")
                {
                    var firstOrLast = command[1];
                    var numberOfShops = int.Parse(command[2]);

                    if (firstOrLast == "first" && numberOfShops >= 0 && numberOfShops <= shops.Count)
                    {
                        shops.RemoveRange(0, numberOfShops);
                    }
                    else if (firstOrLast == "last" && numberOfShops >= 0 && numberOfShops <= shops.Count)
                    {
                        shops.RemoveRange(shops.Count - numberOfShops, numberOfShops);
                    }
                }

                else if (action == "Prefer")
                {
                    var firstIndex = int.Parse(command[1]);
                    var secondIndex = int.Parse(command[2]);

                    if (firstIndex < 0 || firstIndex >= shops.Count || secondIndex < 0 || secondIndex >= shops.Count)
                    {
                        continue;
                    }

                    string tempFirst = shops[firstIndex];
                    string tempSecond = shops[secondIndex];

                    shops[firstIndex] = tempSecond;
                    shops[secondIndex] = tempFirst;
                }
                else if (action == "Place")
                {
                    string shop = command[1];
                    int indexToInsert = int.Parse(command[2]); 

                    if (indexToInsert >= 0 && indexToInsert < shops.Count - 1)
                    {
                        shops.Insert(indexToInsert + 1, shop);
                    }
                    else if (indexToInsert == shops.Count - 1)
                    {
                        shops.Add(shop);
                    }
                }
            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shops));
        }
    }
}
