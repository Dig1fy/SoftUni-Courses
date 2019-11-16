using System;

namespace BalancedBrackets
{
    class Program
    {
        static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int bracketCounter = 0;
            bool isBalanced = true;
            bool isLeftBracketFIrst = true;

            for (int counter = 0; counter < numberOfLines; counter++)
            {
                string input = Console.ReadLine();

                if (input == ")")
                {
                    if (bracketCounter == 0)
                    {
                        isLeftBracketFIrst = false;

                    }
                    if (bracketCounter > 0)
                    {
                        isBalanced = false;
                    }
                    bracketCounter++;
                }
                else if (input == "(")
                {
                    if (bracketCounter < 0)
                    {
                        isBalanced = false;
                    }

                    bracketCounter--;
                }
            }

            if (bracketCounter == 0 && isBalanced && isLeftBracketFIrst)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}