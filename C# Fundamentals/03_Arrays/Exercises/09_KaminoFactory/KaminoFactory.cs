using System;
using System.Linq;

namespace KaminoFactory
{
    class Program
    {
        static void Main()
        {
            int dnaLength = int.Parse(Console.ReadLine());
            const int prDNAfactor = 1;
            char[] separators = new char[] { '!' };

            int[] bestDna = new int[dnaLength];
            int maxRepeat = 0;
            int bestIndex = int.MaxValue;
            int bestSum = 0;
            int bestChain = 1;
            int next = 0;
            string input;

            while ((input = Console.ReadLine()) != "Clone them!")
            {
                int[] array = input
                    .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int sum = array.Sum();
                next++;

                for (int i = 0; i < dnaLength; i++)
                {
                    bool newBest = false;
                    int repeat = 0;

                    if (array[i] == prDNAfactor)
                    {
                        repeat++;

                        for (int j = i + 1; j < dnaLength; j++)
                        {
                            if (array[j] == prDNAfactor)
                            {
                                repeat++;
                            }
                            else break;
                        }
                        //1st Primary condition
                        if (repeat > maxRepeat)
                        {
                            newBest = true;
                        }
                        //2nd
                        else if (repeat == maxRepeat && i < bestIndex)
                        {
                            newBest = true;
                        }
                        //3th
                        else if (repeat == maxRepeat && i == bestIndex && sum > bestSum)
                        {
                            newBest = true;
                        }
                    }

                    if (newBest)
                    {
                        Array.Copy(array, bestDna, dnaLength); //deep array copy
                        bestIndex = i;
                        maxRepeat = repeat;
                        bestSum = sum;
                        bestChain = next;
                    }
                }
            }

            Console.WriteLine($"Best DNA sample {bestChain} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestDna));
        }
    }
}