using System;

namespace ExtractFile
{
    class Program
    {
        static void Main()
        {
            var initial = Console.ReadLine().ToString();
            var lastWords = initial.Substring(initial.LastIndexOf('\\') + 1);
            var fileName = lastWords.Substring(0, lastWords.LastIndexOf('.'));
            var extension = lastWords.Substring(fileName.Length + 1);

            Console.WriteLine($"File name: {fileName}\nFile extension: {extension}");
        }
    }
}
