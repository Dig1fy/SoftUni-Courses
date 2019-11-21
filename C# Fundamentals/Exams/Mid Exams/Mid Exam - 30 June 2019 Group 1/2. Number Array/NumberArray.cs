using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberArray
{
    class Program
    {
        static void Main()
        {
            List<int> inputNums = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArray = command.Split().ToArray();
                string action = commandArray[0];

                switch (action)
                {
                    case "Switch":
                        int tempIndex = int.Parse(commandArray[1]);
                        if (tempIndex >= 0 && tempIndex < inputNums.Count)
                        {
                            inputNums[int.Parse(commandArray[1])] *= -1;
                        }
                        break;
                    case "Change":
                        int index = int.Parse(commandArray[1]);
                        int value = int.Parse(commandArray[2]);

                        if (index >= 0 && index < inputNums.Count)
                        {
                            inputNums[index] = int.Parse(commandArray[2]);
                        }
                        break;
                    case "Sum":
                        if (commandArray[1] == "Negative")
                        {
                            int sum = 0;

                            foreach (var digit in inputNums.Where(x => x < 0))
                            {
                                sum += digit;
                            }

                            Console.WriteLine(sum);
                        }

                        else if (commandArray[1] == "Positive")
                        {
                            int sum = 0;

                            foreach (var digit in inputNums.Where(x => x >= 0))
                            {
                                sum += digit;
                            }

                            Console.WriteLine(sum);
                        }
                        else if (commandArray[1] == "All")
                        {
                            Console.WriteLine(inputNums.Sum());
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", inputNums.Where(x => x >= 0)));
        }
    }
}
