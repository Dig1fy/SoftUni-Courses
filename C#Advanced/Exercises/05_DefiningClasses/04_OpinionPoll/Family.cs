namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public void AddMember(Person person)
        {
            people.Add(person);
            people = people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
        }

        public void Print()
        {
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
