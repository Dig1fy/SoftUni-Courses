using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private int age;
        private string gender;
        private string name;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (IsNotValid(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                name = value;
            }
        }
        

        public int Age
        {
            get { return age; }
            set
            {
                if (IsNotValid(value.ToString()) || value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }

        public string Gender
        {
            get { return gender; }
            set
            {
                if (IsNotValid(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }
        public virtual string ProduceSound()
        {
            return null;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.name} {this.age} {this.gender}");
            sb.Append(ProduceSound());
            return sb.ToString().TrimEnd();
        }
        private static bool IsNotValid(string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }
    }
}
