namespace Collection
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {

            var command = Console.ReadLine();

            var elements = command.Split().Skip(1).ToList();

            ListyIterator<string> listyIterator = new ListyIterator<string>(elements);

            while (command != "END")
            {
                if (command == "Print")
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }
                else if (command == "PrintAll")
                {
                    foreach (var item in listyIterator)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();
                }


                command = Console.ReadLine();

            }
        }
    }
}
