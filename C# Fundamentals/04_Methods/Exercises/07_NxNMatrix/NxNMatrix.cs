using System;

namespace MiddleCharacters
{
    class Program
    {
        static void Main()
        {
            int inputNum = int.Parse(Console.ReadLine());
            InitializeteMatrixWithGivenNumber(inputNum);
        }

        static void InitializeteMatrixWithGivenNumber(int number)
        {
            for (int rows = 0; rows < number; rows++)
            {
                for (int cols = 0; cols < number; cols++)
                {
                    Console.Write(number + " ");
                }

                Console.WriteLine();
            }
        }
    }
}