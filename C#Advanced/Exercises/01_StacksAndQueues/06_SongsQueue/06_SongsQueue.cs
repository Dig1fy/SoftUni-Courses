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

            Queue<string> myQueue = new Queue<string>(Console.ReadLine().Split(", "));

            while (myQueue.Count > 0)
            {

                var entireCommand = Console.ReadLine();
                var command = entireCommand.Split().ToArray();

                if (command[0] == "Play")
                {
                    myQueue.Dequeue();
                }
                else if (command[0] == "Add")
                {
                    if (!myQueue.Contains(entireCommand.Substring(4)))
                    {
                        myQueue.Enqueue(entireCommand.Substring(4));
                    }
                    else
                    {
                        Console.WriteLine($"{entireCommand.Substring(4)} is already contained!");
                    }
                }
                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", myQueue));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}

