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

            var cupsCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var bottlesCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var stackCups = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            var queBottles = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            var wastedWater = 0;


            while (stackCups.Count > 0 && queBottles.Count > 0)
            {
                var currentCup = stackCups.Dequeue();
                var currentBottle = queBottles.Pop();

                if (currentBottle >= currentCup)
                {
                    wastedWater += currentBottle - currentCup;
                }
                else
                {
                    while (currentBottle < currentCup && queBottles.Count > 0)
                    {
                        currentBottle += queBottles.Pop();

                        if (currentBottle >= currentCup)
                        {
                            wastedWater += currentBottle - currentCup;
                        }
                    }
                }
            }

            if (stackCups.Count == 0)
            {
                var bottlesLeft = string.Join(" ", queBottles.ToArray());
                Console.WriteLine($"Bottles: {bottlesLeft} ");
                Console.WriteLine($"Wasted litters of water: { wastedWater}");
            }
            else if (queBottles.Count == 0)
            {
                var cupsLeft = string.Join(" ", stackCups.ToArray());
                Console.WriteLine($"Cups: {cupsLeft} ");
                Console.WriteLine($"Wasted litters of water: { wastedWater}");
            }
        }
    }
}

