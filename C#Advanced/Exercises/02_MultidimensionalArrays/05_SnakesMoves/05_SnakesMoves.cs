using System;
using System.Collections.Generic;
using System.Linq;

namespace MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {

            var matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var snake = Console.ReadLine();
            var rows = matrixSize[0];
            var cols = matrixSize[1];
            var matrix = new char[rows, cols];

            Queue<char> rightSnake = new Queue<char>(snake);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (rightSnake.Count == 0)
                        {
                            rightSnake = new Queue<char>(snake);
                        }

                        matrix[row, col] = rightSnake.Dequeue();
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (rightSnake.Count == 0)
                        {
                            rightSnake = new Queue<char>(snake);
                        }

                        matrix[row, col] = rightSnake.Dequeue();
                    }
                }

            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col].ToString()}");
                }

                Console.WriteLine();
            }
        }
    }
}
