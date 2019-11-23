using System;

namespace ExamOn09And10March2019
{
    class Program
    {
        static void Main()
        {
            int yearFee = int.Parse(Console.ReadLine());

            double shoes = yearFee - (0.4 * yearFee);
            double clothes = shoes - (0.2 * shoes);
            double ball = clothes / 4;
            double accessories = ball / 5;

            double totalSum = yearFee + shoes + clothes + ball + accessories;

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}