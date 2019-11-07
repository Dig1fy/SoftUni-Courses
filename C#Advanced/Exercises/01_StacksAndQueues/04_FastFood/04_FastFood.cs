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
            var totalFood = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var isCompleted = true;
            var myQueue = new Queue<int>(orders);
            var maxOrder = int.MinValue;

            for (int i = 0; i < orders.Length; i++)
            {
                if (myQueue.Peek() > maxOrder)
                {
                    maxOrder = myQueue.Peek();
                }

                if (myQueue.Peek() <= totalFood)
                {
                    totalFood -= myQueue.Dequeue();
                }
                else if (myQueue.Peek() > totalFood)
                {
                    Console.WriteLine(maxOrder);
                    Console.WriteLine($"Orders left: {string.Join(" ", myQueue)}");
                    isCompleted = false;
                    break;
                }
            }

            if (isCompleted)
            {
                Console.WriteLine(maxOrder);
                Console.WriteLine("Orders complete");
            }
        }
    }
}

