namespace GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Engine
    {
        public void Run()
        {
            var totalCapacity = long.Parse(Console.ReadLine());
            var itemsInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            var gold = 0;
            var gems = 0;
            var money = 0;

            for (int i = 0; i < itemsInfo.Length; i += 2)
            {
                var name = itemsInfo[i];
                var currentItemCount = long.Parse(itemsInfo[i + 1]);

                var command = string.Empty;
                command = CheckTheCurrentItem(name, command);

                if (command == "")
                {
                    continue;
                }
                else if (totalCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + currentItemCount)
                {
                    continue;
                }

                switch (command)
                {
                    case "Gem":
                        if (!bag.ContainsKey(command))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (currentItemCount > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[command].Values.Sum() + currentItemCount > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":

                        if (!bag.ContainsKey(command))
                        {

                            if (bag.ContainsKey("Gem"))
                            {
                                if (currentItemCount > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[command].Values.Sum() + currentItemCount > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                CheckIfYouHaveTheItemInTheBag(bag, name, command);

                bag[command][name] += currentItemCount;

                if (command == "Gold")
                {
                    gold += (int)currentItemCount;
                }
                else if (command == "Gem")
                {
                    gems += (int)currentItemCount;
                }
                else if (command == "Cash")
                {
                    money += (int)currentItemCount;
                }
            }

            PrintTheResult(bag);
        }

        private static void PrintTheResult(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var typeOfItem in bag)
            {
                Console.WriteLine($"<{typeOfItem.Key}> ${typeOfItem.Value.Values.Sum()}");

                foreach (var item in typeOfItem.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

        private static void CheckIfYouHaveTheItemInTheBag(Dictionary<string, Dictionary<string, long>> bag, string name, string command)
        {
            if (!bag.ContainsKey(command))
            {
                bag[command] = new Dictionary<string, long>();
            }

            if (!bag[command].ContainsKey(name))
            {
                bag[command][name] = 0;
            }
        }

        private static string CheckTheCurrentItem(string name, string command)
        {
            if (name.Length == 3)
            {
                command = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                command = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                command = "Gold";
            }

            return command;
        }
    }
}
