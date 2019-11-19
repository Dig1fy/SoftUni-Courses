using System;

namespace DataTypes
{
    class Program
    {
        static void Main()
        {
            string type = Console.ReadLine();
            string action = Console.ReadLine();

            switch (type)
            {
                case "int":
                    int resultAsInt = GetIntResult(action); Console.WriteLine(resultAsInt); break;

                case "real":
                    double resultAsDouble = GetRealResult(action);
                    Console.WriteLine($"{resultAsDouble:f2}"); break;

                case "string":
                    GetStringResult(action); break;

                default:
                    break;
            }
        }

        static int GetIntResult(string action)
        {
            int result = int.Parse(action) * 2;
            return result;
        }

        static double GetRealResult(string action)
        {
            double result = double.Parse(action) * 1.5;
            return result;
        }

        static void GetStringResult(string action)
        {
            Console.WriteLine($"${action}$");
        }
    }
}