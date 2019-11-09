namespace Animals
{
    using Cats;
    using Dogs;
    using Frogs;
    using System;
    using System.Text;
    public class StartUp
    {
        private static string animalName;
        private static int animalAge;
        private static string animalGender;        
        static void Main()
        {
            string animalType = Console.ReadLine();
            var stringBuilder = new StringBuilder();
            while (animalType != "Beast!")
            {
                try
                {
                    var animalInfo = Console.ReadLine().Split();
                    animalName = animalInfo[0];
                    animalAge = int.Parse(animalInfo[1]);
                    animalGender = animalInfo[2];

                    stringBuilder.AppendLine(animalType);
                    var currentAnimal = CreateNewSpecificAnimal(animalType);
                    stringBuilder.AppendLine(currentAnimal);                    
                }

                catch (ArgumentException ex)
                {
                    stringBuilder.AppendLine(ex.Message);
                }

                animalType = Console.ReadLine();
            }

            Console.WriteLine(stringBuilder.ToString().TrimEnd());
        }

        private static string CreateNewSpecificAnimal(string type)
        {
            switch (type)
            {
                case "Cat":
                    Cat cat = new Cat(animalName, animalAge, animalGender);
                    return cat.ToString();
                case "Dog":
                    Dog dog = new Dog(animalName, animalAge, animalGender);
                    return dog.ToString();
                case "Frog":
                    Frog frog = new Frog(animalName, animalAge, animalGender);
                    return frog.ToString();
                case "Kitten":
                    Kitten kitten = new Kitten(animalName, animalAge);
                    return kitten.ToString();
                case "Tomcat":
                    Tomcat tomcat = new Tomcat(animalName, animalAge);
                    return tomcat.ToString();
                default:
                    return null;
            }
        }
    }
}
