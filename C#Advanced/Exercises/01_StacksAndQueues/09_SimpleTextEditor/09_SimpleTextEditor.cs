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

            var num = int.Parse(Console.ReadLine());
            var stringBuilder = new StringBuilder();
            var myStack = new Stack<string>();

            myStack.Push(stringBuilder.ToString());

            for (int i = 0; i < num; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .ToArray();

                var command = input[0];

                switch (command)
                {
                    case "1":
                        stringBuilder.Append(input[1]);
                        myStack.Push(stringBuilder.ToString());
                        break;
                    case "2":
                        if (stringBuilder.Length >= int.Parse(input[1]))
                        {
                            stringBuilder.Remove(stringBuilder.Length - int.Parse(input[1]), int.Parse(input[1]));
                            myStack.Push(stringBuilder.ToString());
                        }
                        break;
                    case "3":
                        if (myStack.Count > 0)
                        {
                            var index = int.Parse(input[1]) - 1;
                            Console.WriteLine(stringBuilder[index]);
                        }
                        break;
                    case "4":
                        if (myStack.Count > 0)
                        {

                            myStack.Pop();

                            stringBuilder = new StringBuilder();
                            stringBuilder.Append(myStack.Peek());
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

