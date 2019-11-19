using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main()
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            List<Students> listOfStudents = new List<Students>();

            for (int i = 1; i <= numberOfStudents; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string firstName = input[0];
                string lastName = input[1];
                double grade = double.Parse(input[2]);

                Students currentStudent = new Students(firstName, lastName, grade);
                listOfStudents.Add(currentStudent);
            }

            listOfStudents = listOfStudents.OrderBy(x => x.Grade).ToList();
            listOfStudents.Reverse();
            Console.WriteLine(string.Join(Environment.NewLine, listOfStudents));
        }
    }
}