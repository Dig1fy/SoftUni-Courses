namespace Lake
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake(input);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
