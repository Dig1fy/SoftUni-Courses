using P03_SalesDatabase.IOManagement.Contracts;
using System;

namespace P03_SalesDatabase.IOManagement
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
