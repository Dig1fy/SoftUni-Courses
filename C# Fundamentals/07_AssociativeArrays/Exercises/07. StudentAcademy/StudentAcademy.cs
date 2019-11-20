using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main()
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            var students = new Dictionary<string, List<double>>();

            for (int i = 1; i <= numberOfStudents; i++)
            {
                string currentName = Console.ReadLine();
                double currentGrade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(currentName))
                {
                    students[currentName] = new List<double>();
                }

                students[currentName].Add(currentGrade);
            }

            students = students
                .Where(x => x.Value.Average() >= 4.50)
                .OrderByDescending(x => x.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine(string.Join(Environment.NewLine, students.Select(x => $"{x.Key} -> {x.Value.Average():f2}")));
        }
    }
}