using System;

namespace IntegerOperations
{
    class Program
    {
        static void Main()
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int fourth = int.Parse(Console.ReadLine());

            int result = ((first + second) / third) * fourth;
            Console.WriteLine(result);
        }
    }
}