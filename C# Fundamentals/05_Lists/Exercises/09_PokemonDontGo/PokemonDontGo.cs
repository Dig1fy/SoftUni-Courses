using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            int sumOfRemovedNums = 0;


            while (input.Count > 0)
            {
                int indexToRemove = int.Parse(Console.ReadLine());
                int currentIndexNum = 0;

                if (indexToRemove < 0)
                {
                    currentIndexNum = input[0];
                    input[0] = input[input.Count - 1];
                    AdjustTheList(input, currentIndexNum);
                }

                else if (indexToRemove > input.Count - 1)
                {
                    currentIndexNum = input[input.Count - 1];
                    input[input.Count - 1] = input[0];
                    AdjustTheList(input, currentIndexNum);
                }

                else 
                {
                    currentIndexNum = input[indexToRemove];
                    input.RemoveAt(indexToRemove);

                    AdjustTheList(input, currentIndexNum);
                }

                sumOfRemovedNums += currentIndexNum;
            }

            Console.WriteLine(sumOfRemovedNums);
        }

        private static void AdjustTheList(List<int> input, int currentIndexNum)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] <= currentIndexNum)
                {
                    input[i] += currentIndexNum;
                }
                else if (input[i] > currentIndexNum)
                {
                    input[i] -= currentIndexNum;
                }
            }
        }
    }
}