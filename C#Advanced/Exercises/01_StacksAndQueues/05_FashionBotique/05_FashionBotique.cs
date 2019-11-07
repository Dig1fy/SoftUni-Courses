using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StacksAndQueues
{
    class Program
    {
        static void Main()
        {
            var valuesOfClothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var capacityOfRack = int.Parse(Console.ReadLine());

            var stack = new Stack<int>(valuesOfClothes);

            var racksCount = 0;
            var currentRackCounter = 0;

            while (stack.Count != 0)
            {
                if (currentRackCounter + stack.Peek() > capacityOfRack)
                {
                    racksCount++;
                    currentRackCounter = 0;
                }
                else
                {
                    currentRackCounter += stack.Pop();
                }
            }

            if (currentRackCounter > 0)
            {
                racksCount++;
            }

            Console.WriteLine(racksCount);
        }
    }
}

