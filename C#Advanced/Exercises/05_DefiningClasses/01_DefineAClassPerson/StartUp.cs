namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person();
            person.Name = "Pesho";
            person.Age = 20;

            var person2 = new Person()
            {
                Name = "Gosho",
                Age = 23
            };

        }
    }
}