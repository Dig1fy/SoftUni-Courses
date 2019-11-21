using System;
using System.Text;

namespace StringManipulator
{
    class Program
    {
        static void Main()
        {
            var input = string.Empty;
            var result = Console.ReadLine();
            var tempSolution = string.Empty;
            var builder = new StringBuilder();

            while ((input = Console.ReadLine()) != "End")
            {
                var inputArr = input.Split();
                var action = inputArr[0];

                if (action == "Translate")
                {
                    var charToReplace = char.Parse(inputArr[1]);
                    var replacement = char.Parse(inputArr[2]);
                    result = result.Replace(charToReplace, replacement);
                    builder.AppendLine(result);
                }
                else if (action == "Includes")
                {
                    var checkForThisString = inputArr[1];

                    if (result.Contains(checkForThisString))
                    {
                        builder.AppendLine("True");
                    }
                    else
                    {
                        builder.AppendLine("False");
                    }
                }
                else if (action == "Start")
                {
                    var check = inputArr[1];
                    var checkLength = inputArr[1].Length;
                    var temp = string.Empty;

                    for (int j = 0; j < check.Length; j++)
                    {
                        temp += result[j];
                    }
                    if (temp == check)
                    {
                        builder.AppendLine("True");
                    }
                    else
                    {
                        builder.AppendLine("False");
                    }
                }
                else if (action == "Lowercase")
                {
                    result = result.ToLower();
                    builder.AppendLine($"{result}");
                }
                else if (action == "FindIndex")
                {
                    var charToFind = inputArr[1];
                    var lastIndex = result.LastIndexOf(charToFind);
                    builder.AppendLine($"{lastIndex}");
                }
                else if (action == "Remove")
                {
                    var startIndex = int.Parse(inputArr[1]);
                    var count = int.Parse(inputArr[2]);
                    result = result.Remove(startIndex, count);
                    builder.AppendLine($"{result}");
                }
            }

            Console.WriteLine(builder.ToString());
        }
    }
}