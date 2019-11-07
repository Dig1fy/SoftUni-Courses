namespace Exams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {

            var leftSocks = new Stack<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList());

            var rightSocks = new Queue<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList());

            var pairsOfSocks = new Queue<int>();

            while (leftSocks.Count > 0 && rightSocks.Count > 0)
            {
                var currentLeftSock = leftSocks.Peek();
                var currentRightSock = rightSocks.Peek();

                var currentResult = currentLeftSock.CompareTo(currentRightSock);

                switch (currentResult)
                {
                    case 0:
                        rightSocks.Dequeue();
                        leftSocks.Pop();
                        leftSocks.Push(currentLeftSock+1);
                        break;

                    case 1:
                        pairsOfSocks.Enqueue(currentLeftSock + currentRightSock);
                        leftSocks.Pop();
                        rightSocks.Dequeue();
                        break;     
                    case -1:
                        leftSocks.Pop();
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(pairsOfSocks.Max());
            Console.WriteLine(string.Join(" ", pairsOfSocks));
        }
    }
}
