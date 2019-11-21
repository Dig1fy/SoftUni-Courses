using System;
using System.Linq;

namespace DungeonestDark
{
    class Program
    {
        static void Main()
        {
            int health = 100;
            int coins = 0;

            string[] inputArray = Console.ReadLine().Split("|").ToArray();

            for (int i = 0; i < inputArray.Length; i++)
            {
                string[] input = inputArray[i].Split().ToArray();
                string itemOrMonster = input[0];
                int num = int.Parse(input[1]);

                switch (itemOrMonster)
                {
                    case "potion":
                        if (num + health <= 100)
                        {
                            health += num;
                            Console.WriteLine($"You healed for {num} hp.");
                            Console.WriteLine($"Current health: {health} hp.");
                        }
                        else
                        {
                            int currentPotion = 100 - health;
                            health += currentPotion;
                            Console.WriteLine($"You healed for {currentPotion} hp.");
                            Console.WriteLine($"Current health: {health} hp.");
                        }
                        break;
                    case "chest":
                        coins += num;
                        Console.WriteLine($"You found {num} coins.");
                        break;
                    default:
                        health -= num;
                        if (health <= 0)
                        {
                            Console.WriteLine($"You died! Killed by {itemOrMonster}.");
                            Console.WriteLine($"Best room: {i + 1}"); return;
                        }
                        else
                        {
                            Console.WriteLine($"You slayed {itemOrMonster}.");
                        }
                        break;
                }
            }

            Console.WriteLine($"You've made it!\nCoins: {coins}\nHealth: {health}");
        }
    }
}
