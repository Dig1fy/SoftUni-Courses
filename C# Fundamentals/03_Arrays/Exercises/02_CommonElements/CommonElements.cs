using System;
using System.Linq;

namespace CommonElements
{
    class Program
    {
        static void Main()
        {
            string firstSentence = Console.ReadLine();
            string secondSentence = Console.ReadLine();

            string[] firstSentArray = firstSentence.Split().ToArray();
            string[] secondSentArray = secondSentence.Split().ToArray();

            for (int i = 0; i < secondSentArray.Length; i++)
            {
                for (int k = 0; k < firstSentArray.Length; k++)
                {
                    if (firstSentArray[k] == secondSentArray[i])
                    {
                        Console.Write(firstSentArray[k] + " ");
                    }
                }
            }
        }
    }
}