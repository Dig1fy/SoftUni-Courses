using System;

namespace DataTypeFinder
{
    class Program
    {
        static void Main()
        {
            string command = string.Empty;
            string dataType = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                if (bool.TryParse(command, out bool boolType))
                {
                    dataType = "boolean type";
                }

                else if (int.TryParse(command, out int intType))
                {
                    dataType = "integer type";
                }
                else if (float.TryParse(command, out float floatType))
                {
                    dataType = "floating point type";
                }
                else if (char.TryParse(command, out char charType))
                {
                    dataType = "character type";
                }
                else
                {
                    dataType = "string type";
                }

                Console.WriteLine($"{command} is {dataType}");
            }
        }
    }
}