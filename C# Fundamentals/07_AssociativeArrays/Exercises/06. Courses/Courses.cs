using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main()
        {
            var courses = new Dictionary<string, List<string>>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArr = command.Split(" : ").ToArray();
                string currentModule = commandArr[0];
                string currentStudent = commandArr[1];

                if (!courses.ContainsKey(currentModule))
                {
                    courses.Add(currentModule, new List<string>());
                    courses[currentModule].Add(currentStudent);
                }
                else
                {
                    courses[currentModule].Add(currentStudent);
                }
            }

            courses = courses
                .OrderByDescending(x => x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in courses)
            {
                int students = kvp.Value.Count;

                Console.WriteLine($"{kvp.Key}: {students}");

                foreach (var student in kvp.Value.OrderBy(n => n))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}