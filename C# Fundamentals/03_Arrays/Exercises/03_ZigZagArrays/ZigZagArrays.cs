using System;
using System.Linq;

namespace ZigZagArray
{
    class Program
    {
        static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());
            int[] firstArray = new int[linesCount];
            int[] secondArray = new int[linesCount];
            int counter = 1;

            for (int i = 0; i < linesCount; i++)
            {
                string[] currentLineOfNumbers = Console.ReadLine().Split().ToArray();

                if (counter % 2 == 1)
                {
                    firstArray[i] = int.Parse(currentLineOfNumbers[0]);
                    secondArray[i] = int.Parse(currentLineOfNumbers[1]);
                }
                else
                {
                    firstArray[i] = int.Parse(currentLineOfNumbers[1]);
                    secondArray[i] = int.Parse(currentLineOfNumbers[0]);
                }

                counter++;
            }

            foreach (var firstNumber in firstArray)
            {
                Console.Write(firstNumber + " ");
            }

            Console.WriteLine();

            foreach (var secondNumber in secondArray)
            {
                Console.Write(secondNumber + " ");
            }
        }
    }
}