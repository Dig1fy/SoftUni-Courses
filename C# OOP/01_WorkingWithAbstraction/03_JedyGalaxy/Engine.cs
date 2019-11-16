using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JediGalaxy
{
    public class Engine
    {
        static int[,] matrix;
        public void Run()
        {
            var dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowsSize = dimensions[0];
            var colsSize = dimensions[1];

            matrix = new int[rowsSize, colsSize];
            PopulateMatrix();

            var command = Console.ReadLine();
            var sum = 0L;

            while (command != "Let the Force be with you")
            {
                var ivosCoordinates = GetIvosCoordinates(command);
                var evilsCoordinates = GetEvilsCoordinates();

                var evilsRow = evilsCoordinates[0];
                var evilsCol = evilsCoordinates[1];
                MoveEvilToTheLeftTopCorner(ref evilsRow, ref evilsCol);

                var ivosRow = ivosCoordinates[0];
                var ivosCol = ivosCoordinates[1];
                MovePlayerToTheTopRightCorner(ref sum, ref ivosRow, ref ivosCol);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static int[] GetEvilsCoordinates()
        {
            return Console.ReadLine()
                                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
        }

        private static int[] GetIvosCoordinates(string command)
        {
            return command
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        private static void MovePlayerToTheTopRightCorner(ref long sum, ref int ivosRow, ref int ivosCol)
        {
            while (ivosRow >= 0 && ivosCol < matrix.GetLength(1))
            {
                if (isWithinTheMatrix(ivosRow, ivosCol))
                {
                    sum += matrix[ivosRow, ivosCol];
                }

                ivosCol++;
                ivosRow--;
            }
        }

        private static void MoveEvilToTheLeftTopCorner(ref int evilRow, ref int evilCol)
        {
            while (evilRow >= 0 && evilCol >= 0)
            {
                if (isWithinTheMatrix(evilRow, evilCol))
                {
                    matrix[evilRow, evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
        }

        private static void PopulateMatrix()
        {
            int value = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value;
                    value++;
                }
            }
        }

        private static bool isWithinTheMatrix(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
