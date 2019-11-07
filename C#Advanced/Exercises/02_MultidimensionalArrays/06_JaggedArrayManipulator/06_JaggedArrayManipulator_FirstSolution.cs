using System;
using System.Collections.Generic;
using System.Linq;

namespace MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {

            var numOfRows = int.Parse(Console.ReadLine());
            var jagged = new double[numOfRows][];
            PopulateTheJaggedArray(jagged);

            for (int row = 0; row < jagged.Length; row++)
            {
                if (row + 1 < jagged.Length)
                {
                    AdjustTheJaggedArray(jagged, row);
                }
            }

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var inputArr = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var command = inputArr[0];
                var currentRow = int.Parse(inputArr[1]);
                var currentCol = int.Parse(inputArr[2]);
                var value = double.Parse(inputArr[3]);

                if (command == "Add" && isInRange(jagged, currentRow, currentCol))
                {
                    jagged[currentRow][currentCol] += value;
                }
                else if (command == "Subtract" && isInRange(jagged, currentRow, currentCol))
                {
                    jagged[currentRow][currentCol] -= value;
                }
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jagged[row]));
            }
        }

        private static bool isInRange(double[][] jagged, int currentRow, int currentCol)
        {
            return currentCol >= 0 && currentRow >= 0 && currentRow < jagged.Length &&
                                currentCol < jagged[currentRow].Length;
        }

        private static void AdjustTheJaggedArray(double[][] jagged, int row)
        {
            if (jagged[row].Length == jagged[row + 1].Length)
            {
                for (int rowToChange = row; rowToChange <= row + 1; rowToChange++)
                {
                    for (int colToChange = 0; colToChange < jagged[row].Length; colToChange++)
                    {
                        jagged[rowToChange][colToChange] *= 2;
                    }
                }
            }
            else
            {
                for (int rowToChange = row; rowToChange <= row + 1; rowToChange++)
                {
                    for (int colToChange = 0; colToChange < jagged[rowToChange].Length; colToChange++)
                    {
                        jagged[rowToChange][colToChange] /= 2;
                    }
                }
            }
        }

        private static void PopulateTheJaggedArray(double[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                var colValues = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jagged[row] = new double[colValues.Length];
                jagged[row] = colValues;
            }
        }
    }
}
