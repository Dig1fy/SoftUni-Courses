using System;
using System.Collections.Generic;
using System.Linq;

namespace MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {

            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArr = new double[rows][];

            for (int row = 0; row < jaggedArr.Length; row++)
            {
                double[] currCol = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jaggedArr[row] = currCol;
            }

            AnalyzeArray(jaggedArr);

            while (true)
            {
                string command = Console.ReadLine();

                if (command.ToLower() == "end")
                {
                    break;
                }

                if (command.StartsWith("Add "))
                {
                    Add(jaggedArr, command);
                }
                else if (command.StartsWith("Subtract "))
                {
                    Subtract(jaggedArr, command);
                }
            }

            Print(jaggedArr);

        }
        private static void Print(double[][] jaggedArr)
        {
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArr[row]));
            }
        }

        private static void Subtract(double[][] jaggedArr, string command)
        {
            string[] commandArgs = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int row = int.Parse(commandArgs[1]);
            int col = int.Parse(commandArgs[2]);
            double num = double.Parse(commandArgs[3]);

            try
            {
                jaggedArr[row][col] -= num;
            }
            catch (Exception)
            {
                return;
            }
        }

        private static void Add(double[][] jaggedArr, string command)
        {
            string[] commandArgs = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int row = int.Parse(commandArgs[1]);
            int col = int.Parse(commandArgs[2]);
            int num = int.Parse(commandArgs[3]);

            try
            {
                jaggedArr[row][col] += num;
            }
            catch (Exception)
            {
                return;
            }
        }

        private static void AnalyzeArray(double[][] jaggedArr)
        {
            for (int row = 0; row < jaggedArr.Length - 1; row++)
            {
                if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                {
                    jaggedArr[row] = jaggedArr[row].Select(x => x * 2).ToArray();
                    jaggedArr[row + 1] = jaggedArr[row + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    jaggedArr[row] = jaggedArr[row].Select(x => x / 2).ToArray();
                    jaggedArr[row + 1] = jaggedArr[row + 1].Select(x => x / 2).ToArray();
                }
            }
        }
    }
}
