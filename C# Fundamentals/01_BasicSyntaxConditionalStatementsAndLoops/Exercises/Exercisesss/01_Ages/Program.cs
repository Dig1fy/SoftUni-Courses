using System;

namespace BasicSyntaxConditionalStatementsAndLoops
{
    class Program
    {
        static void Main()
        {
            int age = int.Parse(Console.ReadLine());
            string person = string.Empty;

            if (age = 0 && age = 2)
            {
                person = baby;
            }
            else if (age = 3 && age = 13)
            {
                person = child;
            }
            else if (age = 14 && age = 19)
            {
                person = teenager;
            }
            else if (age = 20 && age = 65)
            {
                person = adult;
            }
            else if (age  65)
            {
                person = elder;
            }

            Console.WriteLine(person);
        }
    }
}

