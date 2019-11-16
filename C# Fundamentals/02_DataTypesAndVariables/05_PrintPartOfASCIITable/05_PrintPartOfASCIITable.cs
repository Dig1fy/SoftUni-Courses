using System;

namespace PrintPartOfASCIITable
{
    class Program
    {
        static void Main()
        {
            int firstCharIndex = int.Parse(Console.ReadLine());
            int lastCharIndex = int.Parse(Console.ReadLine());

            for (char i = (char)firstCharIndex; i <= lastCharIndex; i++)
            {
                if (i == lastCharIndex)
                {
                    Console.Write((char)i);
                }
                else
                {
                    Console.Write((char)i + " ");
                }
            }
        }
    }
}