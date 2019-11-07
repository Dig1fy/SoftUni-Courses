namespace ComparingObjects
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var listOfPeople = new List<Person>();

            while (input != "END")
            {
                var inputInfo = input.Split();
                var name = inputInfo[0];
                var age = int.Parse(inputInfo[1]);
                var town = inputInfo[2];
                var person = new Person(name, age, town);

                listOfPeople.Add(person);

                input = Console.ReadLine();
            }

            var personNumber = int.Parse(Console.ReadLine());

            var desiredPerson = listOfPeople[personNumber - 1];
            var equalPeople = 0;
            var unEqualPeople = 0;

            for (int i = 0; i < listOfPeople.Count; i++)
            {
                if (desiredPerson.CompareTo(listOfPeople[i]) == 0)
                {
                    equalPeople++;
                }
                else
                {
                    unEqualPeople++;
                }
            }

            if (equalPeople > 1)
            {
                Console.WriteLine($"{equalPeople} {unEqualPeople} {listOfPeople.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
