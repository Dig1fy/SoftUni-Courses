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
            var matrix = new char[dimensions, dimensions];
            var maxAttacks = 0;
            var attacks = 0;
            var knightsToRemove = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowValues = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            var rowIndex = 0;
            var colIndex = 0;
            int[] indexes = { -2, -1, -2, 1, -1, -2, -1, 2, 1, -2, 1, 2, 2, -1, 2, 1 };

            while (true)
            {

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            if ((IsInRange(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K'))
                            {
                                attacks++;
                            }
                            if ((IsInRange(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K'))
                            {
                                attacks++;
                            }
                            if ((IsInRange(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K'))
                            {
                                attacks++;
                            }
                            if ((IsInRange(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K'))
                            {
                                attacks++;
                            }
                            if ((IsInRange(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K'))
                            {
                                attacks++;
                            }
                            if ((IsInRange(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K'))
                            {
                                attacks++;
                            }
                            if ((IsInRange(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K'))
                            {
                                attacks++;
                            }
                            if ((IsInRange(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K'))
                            {
                                attacks++;
                            }
                        }

                        if (attacks > maxAttacks)
                        {
                            maxAttacks = attacks;
                            rowIndex = row;
                            colIndex = col;
                        }

                        attacks = 0;
                    }
                }

                if (maxAttacks > 0)
                {
                    knightsToRemove++;
                    matrix[rowIndex, colIndex] = '0';
                    maxAttacks = 0;
                }
                else
                {
                    Console.WriteLine(knightsToRemove);
                    return;
                }
            }
        }

        private static bool IsInRange(char[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) &&
                col < matrix.GetLength(1);
        }
    }
}
