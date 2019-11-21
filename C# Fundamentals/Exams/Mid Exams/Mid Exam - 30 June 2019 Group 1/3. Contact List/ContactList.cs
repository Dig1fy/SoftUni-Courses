using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactList
{
    class Program
    {
        static void Main()
        {
            List<string> inputList = Console.ReadLine()
                   .Split()
                   .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Export")
            {
                string[] commandArray = command
                    .Split()
                    .ToArray();
                string action = commandArray[0];

                switch (action)
                {
                    case "Add":
                        int index = int.Parse(commandArray[2]);

                        if (!inputList.Contains(commandArray[1]))
                        {
                            inputList.Add(commandArray[1]);
                        }
                        else if (index > 0 && index < inputList.Count && inputList.Contains(commandArray[1]))
                        {
                            inputList.Insert(index, commandArray[1]);
                        }
                        break;
                    case "Remove":
                        int tempIndex = int.Parse(commandArray[1]);
                        if (tempIndex >= 0 && tempIndex < inputList.Count)
                        {
                            inputList.RemoveAt(tempIndex);
                        }
                        break;
                    case "Export":
                        int startIndex = int.Parse(commandArray[1]);

                        if (startIndex >= 0 && startIndex < inputList.Count)
                        {
                            if (int.Parse(commandArray[2]) <= inputList.Count)
                            {
                                int tempCounter = 0;

                                for (int i = startIndex; i < inputList.Count; i++)
                                {
                                    if (tempCounter == int.Parse(commandArray[2]))
                                    {
                                        break;
                                    }
                                    tempCounter++;
                                    Console.Write(inputList[i] + " ");
                                }

                                Console.WriteLine();
                            }
                            else
                            {
                                for (int i = startIndex; i < inputList.Count; i++)
                                {
                                    Console.Write(inputList[i] + " ");
                                }

                                Console.WriteLine();
                            }
                        }
                        break;
                    case "Print":
                        if (commandArray[1] == "Normal")
                        {
                            Console.Write("Contacts: ");
                            Console.WriteLine(string.Join(" ", inputList));
                            return;
                        }
                        else if (commandArray[1] == "Reversed")
                        {
                            inputList.Reverse();
                            Console.Write("Contacts: ");
                            Console.WriteLine(string.Join(" ", inputList));
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
