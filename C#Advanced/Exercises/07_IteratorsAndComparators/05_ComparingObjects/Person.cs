namespace ComparingObjects
{
    using System;

    public class Person : IComparable<Person>
    {
        private string name;
        private string town;
        private int age;

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age

        {
            get { return age; }
            set { age = value; }
        }

        public string Town
        {
            get { return town; }
            set { town = value; }
        }

        public int CompareTo( Person other)
        {
            var resultName = this.Name.CompareTo(other.name);

            if (resultName == 0)
            {
                var resultAge = this.Age.CompareTo(other.age);
                if (resultAge == 0)
                {
                    var resultTown = this.Town.CompareTo(other.town);
                    return resultTown;
                }

                return resultAge;
            }

            return resultName;
        }
    }
}
