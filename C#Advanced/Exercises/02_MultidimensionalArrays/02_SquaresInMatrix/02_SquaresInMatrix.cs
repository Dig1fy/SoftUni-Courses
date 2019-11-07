using System;
using System.Linq;

namespace MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {

            var rowsAndCols = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];
            var squareCounter = 0;


            var matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowsValue = Console.ReadLine().Split().ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = char.Parse(rowsValue[col]);
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        squareCounter++;

                    }
                }
            }

            Console.WriteLine(squareCounter);
        }
    }
}
