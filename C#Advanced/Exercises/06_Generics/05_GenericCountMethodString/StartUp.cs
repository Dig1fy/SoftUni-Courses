namespace GenericCountMethod
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var box = new Box<string>();
            var num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                var input = Console.ReadLine();
                box.Add(input);
            }

            var comparedWord = Console.ReadLine();
            Console.WriteLine(box.Check(comparedWord));
        }
    }
}
