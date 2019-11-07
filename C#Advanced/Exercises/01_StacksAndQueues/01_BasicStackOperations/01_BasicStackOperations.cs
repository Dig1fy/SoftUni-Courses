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

            var nPushes = numbers[0];
            var sPops = numbers[1];
            var xCheck = numbers[2];
            var stack = new Stack<int>();

            for (int i = 0; i < Math.Min(nPushes, input.Length); i++)
            {
                stack.Push(input[i]);
            }

            for (int j = 0; j < sPops; j++)
            {
                stack.Pop();
            }

            if (stack.Contains(xCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }

                else Console.WriteLine("0");
            }
        }
    }
}

