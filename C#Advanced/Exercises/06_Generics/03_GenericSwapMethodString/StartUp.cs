namespace GenericBoxOfStrings
{
    using System;
    using System.Linq;
    public class StartUp
    {
        static void Main(string[] args)
        {
            var box = new Box<string>();

            var number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                var currentInput = Console.ReadLine();
                box.Add(currentInput);
            }
            
            var swap = Console.ReadLine().Split().Select(int.Parse).ToArray();            
            var firstIndex = swap[0];
            var secondIndex = swap[1];

            box.Swap(firstIndex, secondIndex);
            Console.WriteLine(box);
        }
    }
}
