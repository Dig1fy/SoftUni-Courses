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

            var stops = int.Parse(Console.ReadLine());
            var myQueue = new Queue<int[]>();

            for (var i = 0; i < stops; i++)
            {
                myQueue.Enqueue(Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray());
            }

            bool canMakeIt = false;


            for (var i = 0; i < stops; i++)
            {
                var fuel = 0;
                foreach (var item in myQueue)
                {
                    fuel += item[0] - item[1];
                    if (fuel < 0)
                    {
                        canMakeIt = false;
                        break;
                    }
                    else
                    {
                        canMakeIt = true;
                    }
                }

                if (canMakeIt)
                {
                    Console.WriteLine(i);
                    return;
                }

                myQueue.Enqueue(myQueue.Dequeue());
            }
        }
    }
}

