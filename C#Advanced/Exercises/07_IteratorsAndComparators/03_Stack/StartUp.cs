namespace Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var customStack = new CustomStack<int>();
            var input = Console.ReadLine();

            while (input != "END")
            {
                var arr = input.Split(" ", 2);

                var stringCommand = arr[0];

                if (stringCommand == "Push")
                {
                    var numbers = arr[1].Split(", ").Select(int.Parse).ToArray();
                    customStack.Push(numbers);
                }
                else
                {
                    try
                    {
                        customStack.Pop();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var g in customStack)
                {
                    Console.WriteLine(g);
                }
            }
        }
    }
}
