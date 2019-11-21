using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterGifts
{
    class Program
    {
        static void Main()
        {
            List<string> gifts = Console.ReadLine()
                .Split()
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "No Money")
            {
                string[] commandArray = command
                    .Split()
                    .ToArray();
                string action = commandArray[0];
                string gift = commandArray[1];

                switch (action)
                {
                    case "OutOfStock":
                        for (int i = 0; i < gifts.Count; i++)
                        {
                            if (gifts[i] == gift)
                            {
                                gifts[i] = "None";
                            }
                        }
                        break;
                    case "Required":
                        int index = int.Parse(commandArray[2]);

                        if (index >= 0 && index < gifts.Count)
                        {
                            gifts[index] = gift;
                        }
                        break;
                    case "JustInCase":
                        if (gifts.Count > 0)
                        {
                            gifts[gifts.Count - 1] = gift;
                        }
                        break;
                    default:
                        break;
                }
            }

            gifts.RemoveAll(x => x == "None");
            Console.WriteLine(string.Join(" ", gifts));
        }
    }
}
