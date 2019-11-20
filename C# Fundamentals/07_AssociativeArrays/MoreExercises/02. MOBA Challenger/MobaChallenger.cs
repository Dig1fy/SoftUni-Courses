using System;
using System.Collections.Generic;
using System.Linq;

namespace MobaChallenger
{
    class Program
    {
        static void Main()
        {
            var playersWithPositionAndPoints = new Dictionary<string, Dictionary<string, int>>();
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "Season end")
            {
                string[] separators = { " ", "->", "vs" };
                var commandArr = command.Split(separators, StringSplitOptions.RemoveEmptyEntries);


                if (commandArr.Length == 3)
                {
                    var player = commandArr[0];
                    var position = commandArr[1];
                    var points = int.Parse(commandArr[2]);

                    if (!playersWithPositionAndPoints.ContainsKey(player))
                    {
                        playersWithPositionAndPoints.Add(player, new Dictionary<string, int>());
                        playersWithPositionAndPoints[player][position] = points;
                    }

                    else if (!playersWithPositionAndPoints[player].ContainsKey(position))
                    {
                        playersWithPositionAndPoints[player].Add(position, points);
                    }

                    else if (playersWithPositionAndPoints[player].ContainsKey(position) &&
                         playersWithPositionAndPoints[player][position] < points)
                    {
                        playersWithPositionAndPoints[player][position] = points;
                    }
                }

                else if (commandArr.Length == 2)
                {
                    var playerOne = commandArr[0];
                    var playerTwo = commandArr[1];
                    bool isThereInCommon = false;
                    var commonPosition = string.Empty;

                    if (!playersWithPositionAndPoints.ContainsKey(playerOne) || !playersWithPositionAndPoints.ContainsKey(playerTwo))
                    {
                        continue;
                    }

                    foreach (var item in playersWithPositionAndPoints[playerOne])
                    {
                        foreach (var item2 in playersWithPositionAndPoints[playerTwo])
                        {
                            if (item.Key == item2.Key)
                            {
                                isThereInCommon = true;
                                commonPosition = item.Key;
                            }
                        }
                    }

                    if (playersWithPositionAndPoints.ContainsKey(playerOne)
                   && playersWithPositionAndPoints.ContainsKey(playerTwo) && isThereInCommon)
                    {
                        if (playersWithPositionAndPoints[playerOne][commonPosition] > playersWithPositionAndPoints[playerTwo][commonPosition])
                        {
                            playersWithPositionAndPoints.Remove(playerTwo);
                        }
                        else if (playersWithPositionAndPoints[playerOne][commonPosition] < playersWithPositionAndPoints[playerTwo][commonPosition])
                        {
                            playersWithPositionAndPoints.Remove(playerOne);
                        }
                    }
                }
            }

            playersWithPositionAndPoints = playersWithPositionAndPoints
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in playersWithPositionAndPoints.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Values.Sum()} skill");

                foreach (var position in kvp.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }
    }
}