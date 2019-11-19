using System;

namespace OrderByAge
{
    class People
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }

        public People(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.Name} with ID: {this.ID} is {this.Age} years old.";
        }
    }
}

