using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalSanctuary
{
    class Program
    {
        static void Main()
        {
            //90 out of 100 points in Judge

            var number = int.Parse(Console.ReadLine());
            var weight = 0;
            var listOfAnimals = new List<string>();
            var builder = new StringBuilder();

            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine();
                listOfAnimals.Clear();

                if (input.Contains("n:") && input.Contains(";t:") && input.Contains(";c--"))
                {
                    var inputToArray = input.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();

                    for (int j = 0; j < inputToArray.Count; j++)
                    {
                        var currentWord = inputToArray[j].TrimStart();
                        var tempWord = string.Empty;

                        for (int k = 1; k < currentWord.Length; k++)
                        {
                            if (char.IsDigit(currentWord[k]))
                            {
                                weight += (currentWord[k] - '0');
                            }

                            else if (char.IsLetter(currentWord[k]) || currentWord[k] == ' ')
                            {
                                tempWord += currentWord[k];
                            }
                        }

                        listOfAnimals.Add(tempWord);
                    }

                    builder.AppendLine($"{listOfAnimals[0]} is a {listOfAnimals[1]} from {listOfAnimals[2]}");
                }
            }

            Console.Write(builder);
            Console.WriteLine($"Total weight of animals: {weight}KG");
        }
    }
}
