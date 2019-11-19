using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> playerOne = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> playerTwo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < Math.Min(playerOne.Count, playerTwo.Count); i++)
            {
                if (playerOne[0] > playerTwo[0])
                {
                    int tempFirst = playerOne[0];
                    int tempSecond = playerTwo[0];
                    playerOne.RemoveAt(0);
                    playerTwo.RemoveAt(0);
                    playerOne.Add(tempFirst);
                    playerOne.Add(tempSecond);
                    i--;
                }
                else if (playerOne[0] < playerTwo[0])
                {
                    int tempFirst = playerOne[0];
                    int tempSecond = playerTwo[0];
                    playerOne.RemoveAt(0);
                    playerTwo.RemoveAt(0);
                    playerTwo.Add(tempSecond);
                    playerTwo.Add(tempFirst);
                    i--;
                }
                else if (playerOne[0] == playerTwo[0])
                {
                    int tempFirst = playerOne[0];
                    int tempSecond = playerTwo[0];
                    playerOne.RemoveAt(0);
                    playerTwo.RemoveAt(0);
                    i--;
                }
            }

            if (playerOne.Count == 0)
            {
                Console.WriteLine($"Second player wins! Sum: {playerTwo.Sum()}");
            }
            else if (playerTwo.Count == 0)
            {
                Console.WriteLine($"First player wins! Sum: {playerOne.Sum()}");
            }
        }
    }
}