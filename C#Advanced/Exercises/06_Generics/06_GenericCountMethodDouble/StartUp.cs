namespace GenericCountMethodDouble
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {

            var box = new Box<double>();

            var num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                var input = double.Parse(Console.ReadLine());
                box.Add(input);
            }

            var comparedWord = double.Parse(Console.ReadLine());
            Console.WriteLine(box.Check(comparedWord));
        }
    }
}
