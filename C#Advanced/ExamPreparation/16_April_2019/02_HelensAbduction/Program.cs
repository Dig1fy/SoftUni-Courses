using System;
using System.Linq;

namespace _02SecondTry
{
    class Program
    {
        static int helenRow;
        static int helenCol;
        static int parisRow;
        static int parisCol;
        static void Main(string[] args)
        {
            var energy = int.Parse(Console.ReadLine());
            var size = int.Parse(Console.ReadLine());

            var matrix = new char[size][];
            PopulateMatrix(matrix);
            var isDead = false;

            matrix[parisRow][parisCol] = '-';

            while (true)
            {
                var command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                var direction = command[0];
                var row = int.Parse(command[1]);
                var col = int.Parse(command[2]);

                if (IsInRange(row, col, matrix))
                {
                    matrix[row][col] = 'S';
                }

                switch (direction)
                {
                    case "up":
                        energy--;
                        if (IsInRange(parisRow - 1, parisCol, matrix))
                        {
                            parisRow--;
                        }
                        break;
                    case "down":
                        energy--;
                        if (IsInRange(parisRow + 1, parisCol, matrix))
                        {
                            parisRow++;
                        }
                        break;
                    case "left":
                        energy--;
                        if (IsInRange(parisRow, parisCol - 1, matrix))
                        {
                            parisCol--;
                        }
                        break;
                    case "right":
                        energy--;
                        if (IsInRange(parisRow, parisCol + 1, matrix))
                        {
                            parisCol++;
                        }
                        break;
                    default:
                        break;
                }

                if (matrix[parisRow][parisCol] == 'S')
                {
                    if (energy > 2)
                    {
                        energy -= 2;
                        matrix[parisRow][parisCol] = '-';
                    }
                    else
                    {
                        matrix[parisRow][parisCol] = 'X';
                        isDead = true;
                        break;
                    }
                }

                if (matrix[parisRow][parisCol] == 'H')
                {
                    matrix[parisRow][parisCol] = '-';
                    break;
                }
                if (energy <= 0)
                {
                    matrix[parisRow][parisCol] = 'X';
                    isDead = true;
                    break;
                }
            }

            if (isDead)
            {
                Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
            }
            else
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(matrix[row]);
            }
        }

        private static bool IsInRange(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static void PopulateMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                var currentRowValues = Console.ReadLine().ToCharArray();

                matrix[row] = currentRowValues;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'H')
                    {
                        helenRow = row;
                        helenCol = col;
                    }
                    else if (matrix[row][col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                }
            }
        }
    }
}
