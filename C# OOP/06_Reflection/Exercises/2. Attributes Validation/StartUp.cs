namespace ValidationAttributes
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 "Jozeph",
                 22
             );

            bool isValidEntity = ValidationAttributes.Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
