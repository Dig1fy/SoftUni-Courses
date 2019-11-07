namespace SeashellTreasure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var listOfSeaShells = new List<char>();
            var matrix = new char[rows][];
            var stolenSeashells = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                var colValues = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                matrix[row] = colValues;
            }

            var commandInfo = string.Empty;

            while ((commandInfo = Console.ReadLine()) != "Sunset")
            {
                var command = commandInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var action = command[0];
                var row = int.Parse(command[1]);
                var col = int.Parse(command[2]);

                if (action == "Collect" && IsInRange(row, col, matrix))
                {
                    if (matrix[row][col] != '-')
                    {
                        listOfSeaShells.Add(matrix[row][col]);
                        matrix[row][col] = '-';
                    }
                }
                else if (action == "Steal" && IsInRange(row, col, matrix))
                {
                    var direction = command[3];

                    if (matrix[row][col] != '-')
                    {
                        stolenSeashells++;
                        matrix[row][col] = '-';
                    }

                    var isAnotherMovePossible = true;

                    for (int i = 1; i <= 3; i++)
                    {
                        if (!isAnotherMovePossible)
                        {
                            break;
                        }
                        switch (direction)
                        {
                            case "up":
                                if (IsInRange(row - 1, col, matrix))
                                {
                                    row--;
                                    stolenSeashells += StealShells(matrix, 0, row, col);
                                }
                                else isAnotherMovePossible = false;
                                break;
                            case "down":
                                if (IsInRange(row + 1, col, matrix))
                                {
                                    row++;
                                    stolenSeashells += StealShells(matrix, 0, row, col);
                                }
                                else isAnotherMovePossible = false;
                                break;
                            case "left":
                                if (IsInRange(row, col - 1, matrix))
                                {
                                    col--;
                                    stolenSeashells += StealShells(matrix, 0, row, col);
                                }
                                else isAnotherMovePossible = false;
                                break;
                            case "right":
                                if (IsInRange(row, col + 1, matrix))
                                {
                                    col++;
                                    stolenSeashells += StealShells(matrix, 0, row, col);
                                }
                                else isAnotherMovePossible = false;
                                break;
                            default:
                                break;
                        }
                    }                    
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
            Console.Write($"Collected seashells: {listOfSeaShells.Count}");

            if (listOfSeaShells.Count > 0)
            {
                Console.Write($" -> {string.Join(", ", listOfSeaShells)}");
            }
            Console.WriteLine();
            

            Console.WriteLine($"Stolen seashells: {stolenSeashells}");
        }

        private static int StealShells(char[][] matrix, int stolenSeashells, int row, int col)
        {
            if (matrix[row][col] != '-')
            {
                stolenSeashells++;
                matrix[row][col] = '-';
            }

            return stolenSeashells;
        }

        private static bool IsInRange(int row, int col, char[][] matrix)
        {
            return (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length);
        }
    }
}
