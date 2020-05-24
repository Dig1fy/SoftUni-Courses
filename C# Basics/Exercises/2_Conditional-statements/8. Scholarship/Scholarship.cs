using System;

namespace ConditionalStatements
{
    class Program
    {
        static void Main()
        {
            double income = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double socialScholarship = Math.Floor(0.35 * minSalary);
            double excellenceScholarship = Math.Floor(averageGrade * 25);


            if (averageGrade <= 4.50)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (averageGrade > 4.50 && averageGrade < 5.50)
            {
                if (income > minSalary)
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }

            }

            if (averageGrade > 4.50 && averageGrade < 5.50 && income < minSalary)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }

            if (averageGrade >= 5.50)
            {
                if (income >= minSalary)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {excellenceScholarship} BGN");
                }
                else
                {
                    if (excellenceScholarship >= socialScholarship)
                    {
                        Console.WriteLine($"You get a scholarship for excellent results {excellenceScholarship} BGN");
                    }
                    else
                    {
                        Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
                    }
                }
            }
        }
    }
}