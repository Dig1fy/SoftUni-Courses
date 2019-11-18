using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int maxCounter = 0;
            int numValue = 0;
            int currentCounter = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == numbers.Length - 1)
                {
                    break;
                }
                if (numbers[i] == numbers[i + 1])
                {
                    currentCounter++;

                    if (currentCounter > maxCounter)
                    {
                        maxCounter = currentCounter;
                        numValue = numbers[i];
                    }
                }
                else
                {
                    currentCounter = 1;
                }
            }

            for (int k = 1; k <= maxCounter; k++)
            {
                Console.Write($"{numValue} ");
            }

            if (maxCounter == 0)
            {
                Console.WriteLine(numbers[0]);
            }
        }
    }
}