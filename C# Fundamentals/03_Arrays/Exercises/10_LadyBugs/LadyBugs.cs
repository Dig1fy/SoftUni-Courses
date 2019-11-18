using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main()
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] fieldSizeArray = new int[fieldSize];
            string input = string.Empty;
            int[] initialPositionsOfAllBugs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int k = 0; k < initialPositionsOfAllBugs.Length; k++)
            {
                if (initialPositionsOfAllBugs[k] < fieldSizeArray.Length && initialPositionsOfAllBugs[k] >= 0)
                {
                    fieldSizeArray[initialPositionsOfAllBugs[k]] = 1;
                }
            }

            while ((input = Console.ReadLine()) != "end")
            {
                string[] move = input.Split().ToArray();
                int bugPosition = int.Parse(move[0]);
                int desiredMoves = int.Parse(move[2]);
                string direction = move[1];


                if (bugPosition > fieldSizeArray.Length - 1 ||
                    bugPosition < 0 || fieldSizeArray[bugPosition] == 0 || desiredMoves == 0)
                {
                    continue;
                }
                if (direction == "left")
                {
                    while (true)
                    {
                        if (bugPosition - desiredMoves < 0 || bugPosition - desiredMoves > (fieldSizeArray.Length - 1))
                        {
                            fieldSizeArray[bugPosition] = 0;
                            break;
                        }
                        else if (fieldSizeArray[bugPosition - desiredMoves] == 1)
                            desiredMoves += desiredMoves;

                        else if (fieldSizeArray[bugPosition - desiredMoves] == 0)
                        {
                            fieldSizeArray[bugPosition] = 0;
                            fieldSizeArray[bugPosition - desiredMoves] = 1;
                            break;
                        }

                    }
                }
                else if (direction == "right")
                {

                    while (true)
                    {

                        if (bugPosition + desiredMoves >= fieldSizeArray.Length)
                        {
                            fieldSizeArray[bugPosition] = 0;
                            break;
                        }
                        else if (fieldSizeArray[bugPosition + desiredMoves] == 1)
                            desiredMoves += desiredMoves;

                        else if (fieldSizeArray[bugPosition + desiredMoves] == 0)
                        {
                            fieldSizeArray[bugPosition] = 0;
                            fieldSizeArray[bugPosition + desiredMoves] = 1;
                            break;
                        }
                    }
                }
            }

            foreach (var num in fieldSizeArray)
            {
                Console.Write(num + " ");
            }
        }
    }
}