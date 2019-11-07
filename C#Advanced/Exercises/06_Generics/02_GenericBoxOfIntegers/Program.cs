namespace GenericBoxOfIntegers
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                var currentInput = int.Parse(Console.ReadLine());
                var box = new Box<int>(currentInput);
                Console.WriteLine(box);
            }
        }
    }
}
