using System;
using System.Linq;

namespace MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {

            var rowsAndCols = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];
            var matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowValues = Console.ReadLine().Split().ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var action = input.Substring(0, 4);

                if (input.Length < 4 || action != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                var inputArr = input.Substring(5).Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (inputArr.Length < 4 || inputArr.Length > 4)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                var currentRow = int.Parse(inputArr[0]);
                var currentCol = int.Parse(inputArr[1]);
                var newRow = int.Parse(inputArr[2]);
                var newCol = int.Parse(inputArr[3]);

                if (currentRow >= 0 && currentCol >= 0 && currentRow < matrix.GetLength(0) &&
                    currentCol < matrix.GetLength(1) && newRow >= 0 && newCol >= 0 &&
                    newRow < matrix.GetLength(0) && newCol < matrix.GetLength(1))
                {
                    var oldPosition = matrix[currentRow, currentCol];
                    var newPosition = matrix[newRow, newCol];
                    matrix[currentRow, currentCol] = newPosition;
                    matrix[newRow, newCol] = oldPosition;

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write($"{matrix[row, col]} ");
                        }

                        Console.WriteLine();
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
