namespace DefiningClasses
{
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
        }

        public Person GetOldestMember()
            => people.OrderByDescending(x => x.Age).FirstOrDefault();

    }
}
