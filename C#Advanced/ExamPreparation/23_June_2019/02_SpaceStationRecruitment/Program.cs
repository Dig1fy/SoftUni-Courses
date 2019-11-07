namespace SpaceStationEstablishment
{
    using System;

    class Program
    {
        static int shipRow;
        static int shipCol;
        static int collectedStars = 0;
        static bool isInVoid = false;
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new char[size, size];
            PopulateMatrix(matrix);
            var checkStars = collectedStars >= 50;

            while (true)
            {
                var currentCommand = Console.ReadLine();
                Move(matrix, currentCommand);

                if (isInVoid)
                {
                    matrix[shipRow, shipCol] = '-';
                    break;
                }

                if (char.IsDigit(matrix[shipRow, shipCol]))
                {
                    collectedStars += (int)(matrix[shipRow, shipCol] - '0');
                    matrix[shipRow, shipCol] = 'S';

                    if (collectedStars >= 50)
                    {
                        break;
                    }
                }
                else if (matrix[shipRow, shipCol] == 'O')
                {
                    GetThroughTheBlackHole(matrix);
                }
            }

            if (collectedStars >= 50)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                Console.WriteLine($"Star power collected: {collectedStars}");
                PrintTheMatrix(matrix);
            }
            else
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
                Console.WriteLine($"Star power collected: {collectedStars}");
                PrintTheMatrix(matrix);
            }
        }

        private static void PrintTheMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void GetThroughTheBlackHole(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'O' && shipRow != row && shipCol != col)
                    {
                        matrix[shipRow, shipCol] = '-';
                        matrix[row, col] = 'S';
                        shipRow = row;
                        shipCol = col;
                    }
                }
            }
        }

        private static void Move(char[,] matrix, string currentCommand)
        {
            switch (currentCommand)
            {
                case "right":
                    if (isInRange(0, 1, matrix))
                        shipCol++;
                    break;
                case "left":
                    if (isInRange(0, -1, matrix))
                        shipCol--;
                    break;
                case "up":
                    if (isInRange(-1, 0, matrix))
                        shipRow--;
                    break;
                case "down":
                    if (isInRange(1, 0, matrix))
                        shipRow++;
                    break;
                default:
                    break;
            }
        }

        private static bool isInRange(int moveRow, int moveCol, char[,] matrix)
        {
            var result = (moveRow + shipRow >= 0 && moveRow + shipRow < matrix.GetLength(0)
                && moveCol + shipCol >= 0 && moveCol + shipCol < matrix.GetLength(1));

            if (result)
            {
                matrix[shipRow, shipCol] = '-';
            }
            else
            {
                isInVoid = true;
            }

            return result;
        }

        private static void PopulateMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var colValues = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colValues[col];

                    if (matrix[row, col] == 'S')
                    {
                        shipRow = row;
                        shipCol = col;
                    }
                }
            }
        }
    }
}
