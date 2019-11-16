using System;

namespace DecryptingMessage
{
    class Program
    {
        static void Main()
        {
            int key = int.Parse(Console.ReadLine());
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int index = 0; index < numberOfLines; index++)
            {
                char input = char.Parse(Console.ReadLine());
                int counter = (int)input + key;
                char currentSymbol = (char)counter;

                Console.Write(currentSymbol);
            }
        }
    }
}