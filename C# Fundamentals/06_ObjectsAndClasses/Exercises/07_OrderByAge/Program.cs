using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<People> listOfPeople = new List<People>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArray = command
                    .Split()
                    .ToArray();
                string name = commandArray[0];
                string id = commandArray[1];
                int age = int.Parse(commandArray[2]);

                People currentPerson = new People(name, id, age);
                listOfPeople.Add(currentPerson);
            }

            listOfPeople = listOfPeople.OrderBy(x => x.Age)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, listOfPeople));
        }        
    }
}