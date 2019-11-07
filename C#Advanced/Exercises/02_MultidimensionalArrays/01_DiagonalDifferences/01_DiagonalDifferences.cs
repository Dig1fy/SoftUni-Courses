using System;
using System.Linq;

namespace Multidimensional_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            var squareSize = int.Parse(Console.ReadLine());

            var matrix = new int[squareSize, squareSize];
            var sumLeftDiagonal = 0;
            var sumRightDiagonal = 0;
            var indexCounter = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var currentRowValue = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = currentRowValue[cols];
                }
            }

            for (int rows = 0; rows < squareSize; rows++)
            {
                sumLeftDiagonal += matrix[rows, indexCounter];
                sumRightDiagonal += matrix[rows, squareSize - indexCounter - 1];

                indexCounter++;
            }

            Console.WriteLine(Math.Abs(sumLeftDiagonal - sumRightDiagonal));
        }
    }
}
