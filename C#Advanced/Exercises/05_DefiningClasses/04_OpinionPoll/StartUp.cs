namespace DefiningClasses
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var numberOfPeople = int.Parse(Console.ReadLine());
            var familyMembers = new Family();

            for (int i = 0; i < numberOfPeople; i++)
            {
                var input =  Console.ReadLine()
                    .Split()
                    .ToArray();

                var currentName = input[0];
                var currentAge = int.Parse(input[1]);

                var person = new Person(currentName, currentAge);
                familyMembers.AddMember(person);                
            }

            familyMembers.Print();
        }
    }
}
