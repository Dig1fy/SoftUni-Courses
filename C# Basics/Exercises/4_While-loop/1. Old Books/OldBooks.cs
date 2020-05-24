using System;

namespace WhileLoop
{
    class Program
    {
        static void Main()
        {
            string wantedBook = Console.ReadLine();
            int libraryCapacity = int.Parse(Console.ReadLine());

            int counter = 0;
            bool foundIt = false;
            string randomBook;

            while (counter < libraryCapacity)
            {

                randomBook = Console.ReadLine();
                if (randomBook == wantedBook)
                {
                    foundIt = true;
                    break;
                }

                counter++;
            }

            if (!(foundIt))
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
            else
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
        }
    }
}