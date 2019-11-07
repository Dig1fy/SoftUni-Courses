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
            var input = Console.ReadLine();
            var stack = new Stack<char>();
            var isBalanced = true;

            for (int i = 0; i < input.Length; i++)
            {

                if (input[i] == '{' || input[i] == '(' || input[i] == '[' || input[i] == ' ')
                {
                    stack.Push(input[i]);
                }
                else if (stack.Count == 0)
                {
                    isBalanced = false;
                    break;
                }
                else
                {
                    if (input[i] == '}' && stack.Peek() != '{')
                    {
                        isBalanced = false;
                        break;
                    }
                    else if (input[i] == ')' && stack.Peek() != '(')
                    {
                        isBalanced = false;
                        break;
                    }
                    else if (input[i] == ']' && stack.Peek() != '[')
                    {
                        isBalanced = false;
                        break;
                    }
                    else if (input[i] == ' ' && stack.Peek() != ' ')
                    {
                        isBalanced = false;
                        break;
                    }
                    stack.Pop();
                }
            }

            if (!isBalanced || stack.Count != 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}

