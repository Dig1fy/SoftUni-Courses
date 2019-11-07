namespace TronRacers
{
    using System;

    class Program
    {
        static int firstPlayerRow;
        static int firstPlayerCol;
        static int secondPlayerRow;
        static int secondPlayerCol;
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new char[size, size];            

            PopulateInitialMatrix(matrix);            

            while (true)
            {
                var commands = Console.ReadLine().Split();
                var newPositions = makeMove(firstPlayerRow,firstPlayerCol,matrix, commands[0]);
                firstPlayerRow = newPositions[0];
                firstPlayerCol = newPositions[1];

                if (checkForEnd(firstPlayerRow, firstPlayerCol, matrix, 's'))
                {
                    matrix[firstPlayerRow, firstPlayerCol] = 'x';
                    break;
                }
                else
                {
                    matrix[firstPlayerRow, firstPlayerCol] = 'f';
                }

                newPositions = makeMove(secondPlayerRow, secondPlayerCol, matrix, commands[1]);
                secondPlayerRow = newPositions[0];
                secondPlayerCol = newPositions[1];

                if (checkForEnd(secondPlayerRow, secondPlayerCol, matrix, 'f'))
                {
                    matrix[secondPlayerRow, secondPlayerCol] = 'x';
                    break;
                }
                else
                {
                    matrix[secondPlayerRow, secondPlayerCol] = 's';
                }
            }

            printMatrix(matrix);
        }

        private static void printMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool checkForEnd(int playerRow, int playerCol, char[,] matrix, char enemySymbol)
        {
            return matrix[playerRow, playerCol] == enemySymbol;
        }

        private static int[] makeMove(int playerRow, int playerCol, char[,] matrix, string direction)
        {
            var xPosition = playerRow;
            var yPosition = playerCol;

            switch (direction)
            {
                case "up":
                    if (xPosition == 0) xPosition = matrix.GetLength(0);
                    xPosition--;
                    break;
                case "down":
                    xPosition++;
                    if (xPosition == matrix.GetLength(0)) xPosition = 0;
                    break;
                case "left":
                    if (yPosition == 0) yPosition = matrix.GetLength(1);
                    yPosition--;
                    break;
                case "right":
                    yPosition++;
                    if (yPosition == matrix.GetLength(1)) yPosition = 0;
                    break;
            }

            return new int[] { xPosition, yPosition };
        }       

        private static void PopulateInitialMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowValues = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowValues[col];

                    if (matrix[row, col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    if (matrix[row, col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }
        }
    }
}
