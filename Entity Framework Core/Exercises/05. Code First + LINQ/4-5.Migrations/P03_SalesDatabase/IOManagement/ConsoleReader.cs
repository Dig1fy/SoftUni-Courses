using P03_SalesDatabase.IOManagement.Contracts;
using System;

namespace P03_SalesDatabase.IOManagement
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
