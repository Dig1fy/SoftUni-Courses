using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {                
                input[i] += (char)('3' - '0');
            }

            Console.WriteLine(input);
        }
    }
}
