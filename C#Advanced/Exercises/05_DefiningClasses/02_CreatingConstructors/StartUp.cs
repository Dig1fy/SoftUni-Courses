namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person();
            person.Name = "F";
            person.Age = 20;

            var person2 = new Person()
            {
                Name = "Gosho",
                Age = 23
            };

        }
    }
}
