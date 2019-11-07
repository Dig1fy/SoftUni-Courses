namespace ExcelFunctions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var jagged = new string[num][];
            PopulateMatrix(num, jagged);

            var commandInfo = Console.ReadLine().Split(" ");
            var command = commandInfo[0];
            var header = commandInfo[1];
            var headerIndex = Array.IndexOf(jagged[0], header);

            if (command == "hide")
            {
                for (int row = 0; row < jagged.Length; row++)
                {
                    var currentRow = new List<string>(jagged[row]);
                    currentRow.RemoveAt(headerIndex);
                    Console.WriteLine(string.Join(" | ", currentRow));
                }
            }

            else if (command == "sort")
            {
                var headRow = jagged[0];
                Console.WriteLine(string.Join(" | ", headRow));

                jagged = jagged.OrderBy(x => x[headerIndex]).ToArray();

                foreach (var row in jagged)
                {
                    if (row != headRow)
                    {
                        Console.WriteLine(string.Join(" | ", row));
                    }
                }
            }

            else if (command == "filter")
            {
                var value = commandInfo[2];
                Console.WriteLine(string.Join(" | ", jagged[0]));

                for (int row = 0; row < jagged.Length; row++)
                {
                    if (jagged[row][headerIndex] == value)
                    {
                        Console.WriteLine(string.Join(" | ", jagged[row]));                        
                    }
                }
            }
        }

        private static void PopulateMatrix(int num, string[][] jagged)
        {
            for (int i = 0; i < num; i++)
            {
                var rowsValues = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                jagged[i] = rowsValues;
            }
        }
    }
}
