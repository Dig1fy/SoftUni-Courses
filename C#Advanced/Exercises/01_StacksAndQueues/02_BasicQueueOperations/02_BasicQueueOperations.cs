using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueues
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var myQueue = new Queue<int>();

            var numbersToEnqueue = numbers[0];
            var numbersToDequeue = numbers[1];
            var numbersToCheck = numbers[2];

            for (int i = 0; i < Math.Min(numbersToEnqueue, input.Length); i++)
            {
                myQueue.Enqueue(input[i]);
            }

            var currentCountOfQueue = myQueue.Count;

            for (int j = 0; j < Math.Min(numbersToDequeue, currentCountOfQueue); j++)
            {
                myQueue.Dequeue();
            }

            bool check = myQueue.Contains(numbersToCheck);

            if (check)
            {
                Console.WriteLine("true");
            }
            else
            {
                if (myQueue.Count > 0)
                {
                    Console.WriteLine(myQueue.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}

