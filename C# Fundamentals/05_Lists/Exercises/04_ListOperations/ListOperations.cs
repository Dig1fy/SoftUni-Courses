using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command
                    .Split()
                    .ToArray();
                string action = input[0];

                switch (action)
                {
                    case "Add":
                        numbers.Add(int.Parse(input[1])); 
                        break;

                    case "Insert":
                        if (int.Parse(input[2]) < 0 || int.Parse(input[2]) >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        int index = int.Parse(input[2]);
                        int element = int.Parse(input[1]);
                        numbers.Insert(index, element); 
                        break;

                    case "Remove":
                        if (int.Parse(input[1]) < 0 || int.Parse(input[1]) >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        numbers.RemoveAt(int.Parse(input[1])); 
                        break;

                    case "Shift":
                        if (input[1] == "left")
                        {
                            for (int i = 0; i < int.Parse(input[2]); i++)
                            {
                                int lastNumber = numbers[0];
                                numbers.RemoveAt(0);
                                numbers.Add(lastNumber);
                            }
                        }
                        else if (input[1] == "right")
                        {
                            for (int i = 0; i < int.Parse(input[2]); i++)
                            {
                                int firstNumber = numbers[numbers.Count - 1];
                                numbers.RemoveAt(numbers.Count - 1);
                                numbers.Insert(0, firstNumber);

                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}