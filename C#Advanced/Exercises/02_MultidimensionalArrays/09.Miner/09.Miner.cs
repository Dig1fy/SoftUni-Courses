using System;
using System.Collections.Generic;
using System.Linq;

namespace MultidimensionalArrays
{
    class Program
    {
        static char[,] matrix;
        static int minerRow;
        static int minerCol;
        static int coalsTotal;

        static void Main(string[] args)
        {

            var dimensions = int.Parse(Console.ReadLine());
            var directions = Console.ReadLine()
                .Split()
                .ToArray();

            matrix = new char[dimensions, dimensions];

            PopulateMatrix();

            foreach (var move in directions)
            {
                switch (move)
                {
                    case "up":
                        Move(-1, 0);
                        break;
                    case "down":
                        Move(1, 0);
                        break;
                    case "left":
                        Move(0, -1);
                        break;
                    case "right":
                        Move(0, 1);
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine($"{coalsTotal} coals left. ({minerRow}, {minerCol})");            
        }

        private static void Move(int row, int col)
        {
            if (IsInsideTheArray(minerRow + row, minerCol + col))
            {
                minerRow += row;
                minerCol += col;

                if (matrix[minerRow, minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    Environment.Exit(0);
                }
                else if (matrix[minerRow, minerCol] == 'c')
                {
                    coalsTotal--;
                    if (coalsTotal == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                        Environment.Exit(0);
                    }
                    matrix[minerRow, minerCol] = '*';
                }
            }
        }

        private static bool IsInsideTheArray(int row, int col)
        {
            return (row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1));
        }

        private static void PopulateMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var colValues = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colValues[col];

                    if (matrix[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    else if (matrix[row, col] == 'c')
                    {
                        coalsTotal++;
                    }
                }
            }
        }
    }
}
