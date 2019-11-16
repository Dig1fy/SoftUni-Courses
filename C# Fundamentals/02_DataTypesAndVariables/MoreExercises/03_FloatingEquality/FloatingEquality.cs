using System;

namespace FloatingEquality
{
    class Program
    {
        static void Main()
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());

            double eps = 0.000001;

            if (Math.Max(firstNum, secondNum) - Math.Min(firstNum, secondNum) >= eps)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }
        }
    }
}