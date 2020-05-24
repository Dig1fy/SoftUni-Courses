using System;

namespace NestedLoops
{
    class Program
    {
        static void Main()
        {
            int smaller = int.Parse(Console.ReadLine());
            int bigger = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;
            int middleSum = 0;
            int currentNumber = 0;

            for (int i = smaller; i <= bigger; i++)
            {
                currentNumber = i;
                leftSum = 0;
                rightSum = 0;
                middleSum = 0;
                for (int fi = 5; fi >= 0; fi--)
                {
                    int numCounter = currentNumber % 10;
                    currentNumber = currentNumber / 10;

                    if (fi > 3)
                    {
                        rightSum += numCounter;
                    }
                    else if (fi == 3)
                    {
                        middleSum += numCounter;
                    }
                    else if (fi < 3)
                    {
                        leftSum += numCounter;
                    }
                }

                if (leftSum == rightSum)
                {
                    Console.Write(i + " ");
                }
                else if (leftSum < rightSum && leftSum + middleSum == rightSum)
                {
                    Console.Write(i + " ");
                }
                else if (leftSum > rightSum && leftSum == middleSum + rightSum)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}