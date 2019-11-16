namespace Sneaking
{
    using System;

    public class Engine
    {
        private static int enemyRow = 0;
        private static int enemyColumn = 0;
        private static int samsRow = 0;
        private static int samsColumn = 0;
        private static char[][] matrix;
        public void Run()
        {
            var rowsSize = int.Parse(Console.ReadLine());
            matrix = new char[rowsSize][];
            PopulateTheMatrix(rowsSize);

            var moves = Console.ReadLine().ToCharArray();
            GetSamsPosition(ref samsRow, ref samsColumn);

            for (int i = 0; i < moves.Length; i++)
            {
                MoveTheEnemies();
                GetCurrentEnemysPosition();

                if (LeftMovingEnemyKillsSam() || RightMovingEnemyKillsSam())
                {
                    PrintTheResult();
                    break;
                }

                matrix[samsRow][samsColumn] = '.';
                AdjustSamsPosition(moves, i);
                matrix[samsRow][samsColumn] = 'S';

                GetCurrentEnemysPosition();
                if (SamKillsNikoladze())
                {
                    PrintTheVictoryMatrix();
                    break;
                }
            }
        }

        private static void PrintTheVictoryMatrix()
        {
            matrix[enemyRow][enemyColumn] = 'X';
            Console.WriteLine("Nikoladze killed!");
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static bool SamKillsNikoladze()
        {
            return matrix[enemyRow][enemyColumn] == 'N' && samsRow == enemyRow;
        }

        private static void AdjustSamsPosition(char[] moves, int i)
        {
            switch (moves[i])
            {
                case 'U':
                    samsRow--;
                    break;
                case 'D':
                    samsRow++;
                    break;
                case 'L':
                    samsColumn--;
                    break;
                case 'R':
                    samsColumn++;
                    break;
                default:
                    break;
            }
        }

        private static void PrintTheResult()
        {
            matrix[samsRow][samsColumn] = 'X';
            Console.WriteLine($"Sam died at {samsRow}, {samsColumn}");
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static bool RightMovingEnemyKillsSam()
        {
            return enemyColumn < samsColumn && matrix[enemyRow][enemyColumn] == 'b' && enemyRow == samsRow;
        }
        private static bool LeftMovingEnemyKillsSam()
        {
            return samsColumn < enemyColumn && matrix[enemyRow][enemyColumn] == 'd' && enemyRow == samsRow;
        }

        private static void GetCurrentEnemysPosition()
        {
            for (int col = 0; col < matrix[samsRow].Length; col++)
            {
                if (matrix[samsRow][col] != '.' && matrix[samsRow][col] != 'S')
                {
                    enemyRow = samsRow;
                    enemyColumn = col;
                }
            }
        }

        private static void MoveTheEnemies()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        if (row >= 0 && row < matrix.Length && col + 1 >= 0 && col + 1 < matrix[row].Length)
                        {
                            matrix[row][col] = '.';
                            matrix[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            matrix[row][col] = 'd';
                        }
                    }
                    else if (matrix[row][col] == 'd')
                    {
                        if (row >= 0 && row < matrix.Length && col - 1 >= 0 && col - 1 < matrix[row].Length)
                        {
                            matrix[row][col] = '.';
                            matrix[row][col - 1] = 'd';
                        }
                        else
                        {
                            matrix[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private static void GetSamsPosition(ref int samsRow, ref int samsColumn)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        samsRow = row;
                        samsColumn = col;
                    }
                }
            }
        }

        private static void PopulateTheMatrix(int n)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                matrix[row] = input;
            }
        }
    }
}
