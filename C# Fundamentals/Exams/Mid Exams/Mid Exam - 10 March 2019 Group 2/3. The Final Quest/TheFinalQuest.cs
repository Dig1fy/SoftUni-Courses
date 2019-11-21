using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFinalQuest
{
    class Program
    {
        static void Main()
        {
            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] commandArray = command
                    .Split()
                    .ToArray();
                string action = commandArray[0];

                if (action == "Delete")
                {
                    int index = int.Parse(commandArray[1]);
                    if (index >= 0 && index < input.Count - 1)
                    {
                        input.RemoveAt(index + 1);
                    }
                }

                else if (action == "Swap")
                {
                    string word1 = commandArray[1];
                    string word2 = commandArray[2];

                    if (input.Contains(word1) && input.Contains(word2))
                    {
                        int indexWord1 = input.IndexOf(word1);
                        int indexWord2 = input.IndexOf(word2);

                        input[indexWord1] = word2;
                        input[indexWord2] = word1;
                    }
                }

                else if (action == "Put")
                {
                    string word = commandArray[1];
                    int index = int.Parse(commandArray[2]);

                    if (index >= 1 && index <= input.Count + 1)
                    {
                        input.Insert(index - 1, word);
                    }
                }

                else if (action == "Sort")
                {
                    input.Sort();
                    input.Reverse();
                }

                else if (action == "Replace")
                {
                    string word1 = commandArray[1];
                    string word2 = commandArray[2];

                    if (input.Contains(word2))
                    {
                        input[input.IndexOf(word2)] = word1;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
