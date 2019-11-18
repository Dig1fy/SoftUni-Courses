using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int sum = Sum(firstNum, secondNum);
            int result = Subtract(sum, thirdNum);
            Console.WriteLine(result);
        }

        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}
