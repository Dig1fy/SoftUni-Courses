using System;

namespace ASCIISumator
{
    class Program
    {
        static void Main()
        {
            var firstSymbol = char.Parse(Console.ReadLine());
            var secondSymbol = char.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            var sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > firstSymbol && input[i] < secondSymbol)
                {
                    sum += input[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
