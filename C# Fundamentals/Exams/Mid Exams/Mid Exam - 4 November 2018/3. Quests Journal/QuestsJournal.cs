using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestsJournal
{
    class Program
    {
        static void Main()
        {
            List<string> initialInput = Console.ReadLine()
                .Split(", ")
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Retire!")
            {

                string[] commandArray = command
                    .Split(" - ")
                    .ToArray();
                string action = commandArray[0];
                string quest = commandArray[1];

                if (action == "Start" && !initialInput.Contains(quest))
                {
                    initialInput.Add(quest);
                }

                else if (action == "Complete" && initialInput.Contains(quest))
                {
                    initialInput.RemoveAll(x => x.Equals(quest));
                }

                else if (action == "Side Quest")
                {
                    string[] temp = commandArray[1]
                        .Split(":")
                        .ToArray();
                    string tempQuest = temp[0];
                    string tempSideQUest = temp[1];

                    if (initialInput.Contains(tempQuest) && !initialInput.Contains(tempSideQUest))
                    {
                        int indexOfQuest = initialInput.IndexOf(tempQuest);
                        initialInput.Insert(indexOfQuest + 1, tempSideQUest);
                    }
                }

                else if (action == "Renew" && initialInput.Contains(quest))
                {
                    initialInput.Remove(quest);
                    initialInput.Add(quest);
                }
            }

            Console.WriteLine(string.Join(", ", initialInput));
        }
    }
}
