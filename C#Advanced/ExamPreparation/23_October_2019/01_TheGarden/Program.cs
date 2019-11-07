namespace TheGarden
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var garden = new char[rows][];
            var allHarvests = new List<char>();
            var carrotValue = 0;
            var potatoesValue = 0;
            var lettuceValue = 0;
            var harmedValue = 0;

            for (int row = 0; row < rows; row++)
            {
                var colValues = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                garden[row] = colValues;
            }

            var commandInfo = string.Empty;

            while ((commandInfo = Console.ReadLine().ToLower()) != "end of harvest")
            {
                var command = commandInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var action = command[0];
                var row = int.Parse(command[1]);
                var col = int.Parse(command[2]);

                if (action == "harvest" && IsInRange(row, col, garden))
                {
                    if (garden[row][col] != ' ')
                    {
                        allHarvests.Add(garden[row][col]);
                        garden[row][col] = ' ';
                    }
                }
                else if (action == "mole" && IsInRange(row, col, garden))
                {
                    if (garden[row][col] != ' ')
                    {
                        garden[row][col] = ' ';
                        harmedValue++;
                    }

                    var isInBound = true;

                    while (true)
                    {
                        if (!isInBound)
                        {
                            break;
                        }

                        var direction = command[3];

                        switch (direction)
                        {
                            case "up":
                                if (IsInRange(row + 2, col, garden))
                                {
                                    row += 2;
                                    AdjustCurrentCol(garden, allHarvests, row, col);
                                    harmedValue++;
                                }
                                else isInBound = false;
                                break;
                            case "down":
                                if (IsInRange(row - 2, col, garden))
                                {
                                    row -= 2;
                                    AdjustCurrentCol(garden, allHarvests, row, col);
                                    harmedValue++;
                                }
                                else isInBound = false;
                                break;
                            case "left":
                                if (IsInRange(row, col - 2, garden))
                                {
                                    col -= 2;
                                    AdjustCurrentCol(garden, allHarvests, row, col);
                                    harmedValue++;
                                }
                                else isInBound = false;
                                break;
                            case "right":
                                if (IsInRange(row, col + 2, garden))
                                {
                                    col += 2;
                                    AdjustCurrentCol(garden, allHarvests, row, col);
                                    harmedValue++;
                                }
                                else isInBound = false;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            foreach (var item in allHarvests)
            {
                switch (item)
                {
                    case 'P': potatoesValue++; break;
                    case 'L': lettuceValue++; break;
                    case 'C': carrotValue++; break;
                    default:
                        break;
                }
            }

            for (int row = 0; row < garden.Length; row++)
            {
                Console.WriteLine(string.Join(" ", garden[row]));
            }

            Console.WriteLine($"Carrots: {carrotValue}");
            Console.WriteLine($"Potatoes: {potatoesValue}");
            Console.WriteLine($"Lettuce: {lettuceValue}");
            Console.WriteLine($"Harmed vegetables: {harmedValue}");
        }

        private static void AdjustCurrentCol(char[][] garden, List<char> allHarvests, int row, int col)
        {
            if (garden[row][col] != ' ')
            {
                garden[row][col] = ' ';
            }
        }

        private static bool IsInRange(int row, int col, char[][] garden)
        {
            return (row >= 0 && row < garden.Length && col >= 0 && col < garden[row].Length);
        }
    }
}
