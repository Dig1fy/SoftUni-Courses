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
            var numberOfOperations = int.Parse(Console.ReadLine());
            var myStack = new Stack<int>();
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < numberOfOperations; i++)
            {
                var currentCommand = Console.ReadLine()
                    .Split()
                    .ToArray();

                var action = currentCommand[0];

                switch (action)
                {
                    case "1":
                        var numToPush = int.Parse(currentCommand[1]);
                        myStack.Push(numToPush); break;
                    case "2":
                        if (myStack.Count > 0)
                        {
                            myStack.Pop();
                        }
                        break;
                    case "3":
                        if (myStack.Count > 0)
                        {
                            stringBuilder.AppendLine(myStack.Max().ToString());
                        }
                        break;
                    case "4":
                        if (myStack.Count > 0)
                        {
                            stringBuilder.AppendLine(myStack.Min().ToString());
                        }
                        break;
                    default:
                        break;
                }

            }

            stringBuilder.Append(string.Join(", ", myStack));
            Console.WriteLine(string.Join(Environment.NewLine, stringBuilder));
        }
    }
}

