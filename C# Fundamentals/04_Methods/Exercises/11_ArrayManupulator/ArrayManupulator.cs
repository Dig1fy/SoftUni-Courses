using System;
using System.Linq;

namespace ArrayManipulator
{
    class Program
    {
        static void Main()
        {
            var initialArray = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                var commands = input.Split(" ");

                if (commands[0] == "exchange")
                {
                    var splitIndex = int.Parse(commands[1]);

                    if (splitIndex < initialArray.Length && splitIndex >= 0)
                    {
                        Exchange(initialArray, splitIndex);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }

                else if (commands[0] == "max" || commands[0] == "min")
                {
                    Console.WriteLine(GetEvenOrOddNumber(initialArray, commands[0], commands[1]));
                }

                else if (commands[0] == "first" || commands[0] == "last")
                {
                    var count = int.Parse(commands[1]);

                    if (count <= initialArray.Length)
                    {
                        Console.WriteLine("[" + FirstLast(EvenOdd(initialArray, commands[2]), commands[0], count) + "]");
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                }
            }

            Console.WriteLine("[" + string.Join(", ", initialArray) + "]");
        }

        static void Exchange(int[] array, int splitIndex)
        {
            int[] exchangedArr = new int[array.Length];
            int indexExchArr = 0;

            for (int i = splitIndex + 1; i < array.Length; i++)
            {
                exchangedArr[indexExchArr] = array[i];
                indexExchArr++;
            }

            for (int i = 0; i <= splitIndex; i++)
            {
                exchangedArr[indexExchArr] = array[i];
                indexExchArr++;
            }

            Array.Copy(exchangedArr, array, array.Length);
        }

        static string GetEvenOrOddNumber(int[] arr, string maxMin, string evenOdd)
        {
            var index = -1;
            var max = int.MinValue;
            var min = int.MaxValue;

            var resultFromModDiv = 0;

            if (evenOdd == "odd")
            {
                resultFromModDiv = 1;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == resultFromModDiv)
                {
                    if (maxMin == "min")
                    {
                        if (arr[i] <= min)
                        {
                            index = i;
                            min = arr[i];
                        }
                    }
                    else if (maxMin == "max")
                    {
                        if (arr[i] >= max)
                        {
                            index = i;
                            max = arr[i];
                        }
                    }
                }
            }

            if (index >= 0)
            {
                return index.ToString();
            }

            return "No matches";
        }

        static int[] EvenOdd(int[] arr, string evenOdd)
        {
            var evenOrOdd = new int[arr.Length];
            var index = 0;

            var resultFromModDiv = 0;

            if (evenOdd == "odd")
            {
                resultFromModDiv = 1;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == resultFromModDiv)
                {
                    evenOrOdd[index] = arr[i];
                    index++;
                }
            }

            arr = new int[index];
            Array.Copy(evenOrOdd, arr, index);
            return arr;
        }

        static string FirstLast(int[] inputArray, string firstLast, int count)
        {
            var newArray = new int[inputArray.Length];
            var index = 0;

            if (firstLast == "first")
            {
                for (int i = 0; i < count && i < inputArray.Length; i++)
                {
                    newArray[index] = inputArray[i];
                    index++;
                }
            }
            else if (firstLast == "last")
            {
                if (count > inputArray.Length)
                {
                    count = inputArray.Length;
                }

                for (int i = inputArray.Length - count; i < inputArray.Length; i++)
                {
                    newArray[index] = inputArray[i];
                    index++;
                }
            }

            inputArray = new int[index];

            Array.Copy(newArray, inputArray, index);

            return string.Join(", ", inputArray);
        }
    }
}