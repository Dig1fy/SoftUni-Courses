using System;
using System.Linq;

namespace ValidUsernames
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(", ").ToList();

            for (int i = 0; i < input.Count; i++)
            {
                bool isLength = (input[i].Length >= 3 && input[i].Length <= 16);

                if (isLength == false)
                {
                    continue;
                }

                bool isLegit = true;

                foreach (var symbol in input[i])
                {
                    if (symbol != '-' && symbol != '_' && !char.IsLetterOrDigit(symbol))
                    {
                        isLegit = false;
                        break;
                    }
                }

                if (isLegit && isLength)
                {
                    Console.WriteLine(input[i]);
                }
            }
        }
    }
}
