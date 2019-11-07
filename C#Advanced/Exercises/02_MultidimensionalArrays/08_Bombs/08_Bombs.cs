using System;
using System.Collections.Generic;
using System.Linq;

namespace MultidimensionalArrays
{
    class Program
    {

        static void Main(string[] args)
        {

            var dimensions = int.Parse(Console.ReadLine());
            var matrix = new int[dimensions, dimensions];


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var colValues = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colValues[col];
                }
            }

            var bombs = Console.ReadLine().Split().ToArray();

            for (int bombIndexes = 0; bombIndexes < bombs.Length; bombIndexes++)
            {
                var currentBomb = bombs[bombIndexes].Split(",").Select(int.Parse).ToArray();
                var bombRow = currentBomb[0];
                var bombCol = currentBomb[1];
                var bombValue = matrix[bombRow, bombCol];

                if (matrix[bombRow, bombCol] > 0)
                {
                    ExplosionsAroundTheBomb(matrix, bombRow, bombCol, bombValue);
                }
            }

            PrintTheMatrix(matrix);
        }

        private static void PrintTheMatrix(int[,] matrix)
        {
            var aliveCells = 0;
            var sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        sum += matrix[row, col];
                        aliveCells++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static void ExplosionsAroundTheBomb(int[,] matrix, int bombRow, int bombCol, int bombValue)
        {
            AdjustTheExplodedCells(matrix, bombRow - 1, bombCol, bombValue);
            AdjustTheExplodedCells(matrix, bombRow - 1, bombCol - 1, bombValue);
            AdjustTheExplodedCells(matrix, bombRow - 1, bombCol + 1, bombValue);
            AdjustTheExplodedCells(matrix, bombRow, bombCol - 1, bombValue);
            AdjustTheExplodedCells(matrix, bombRow, bombCol + 1, bombValue);
            AdjustTheExplodedCells(matrix, bombRow + 1, bombCol - 1, bombValue);
            AdjustTheExplodedCells(matrix, bombRow + 1, bombCol, bombValue);
            AdjustTheExplodedCells(matrix, bombRow + 1, bombCol + 1, bombValue);
            matrix[bombRow, bombCol] = 0;
        }

        private static void AdjustTheExplodedCells(int[,] matrix, int row, int col, int bombValue)
        {
            if (row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1) && matrix[row, col] > 0)
            {
                matrix[row, col] -= bombValue;
            }
        }
    }
}
