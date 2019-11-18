using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main()
        {
            int inputNum = int.Parse(Console.ReadLine());
            int[] initialArray = { 1, 1 };

            for (int i = 0; i < inputNum; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("1");
                    continue;
                }
                else if (i == 1)
                {

                    Console.WriteLine(string.Join(" ", initialArray));

                    if (inputNum == 1)
                    {
                        break;
                    }

                    continue;
                }

                int[] currentAray = new int[i + 1];
                currentAray[0] = 1;
                currentAray[currentAray.Length - 1] = 1;

                for (int k = 1; k < currentAray.Length - 1; k++)
                {
                    currentAray[k] = initialArray[k] + initialArray[k - 1];
                }

                Console.WriteLine(string.Join(" ", currentAray));
                initialArray = currentAray;
            }
        }
    }
}