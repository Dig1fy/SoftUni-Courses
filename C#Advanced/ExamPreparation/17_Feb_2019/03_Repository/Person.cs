namespace Repository
{
    using System;

    public class Person
    {
        private string name;
        private int age;
        private DateTime dateTime;

        public Person(string name, int age, DateTime birthdate)
        {
            Name = name;
            Age = age;
            Birthdate = birthdate;
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
        public DateTime Birthdate
        {
            get { return dateTime; }
            set { dateTime = value; }
        }
    }
}
