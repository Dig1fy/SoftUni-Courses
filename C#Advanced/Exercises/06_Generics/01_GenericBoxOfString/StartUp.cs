namespace GenericBoxOfStrings
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                var currentInput = Console.ReadLine();
                var box = new Box<string>(currentInput);
                Console.WriteLine(box);
            }
        }
    }
}
