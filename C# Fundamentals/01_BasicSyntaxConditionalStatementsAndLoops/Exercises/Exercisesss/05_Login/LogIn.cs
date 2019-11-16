using System;

namespace Login
{
    class Program
    {
        static void Main()
        {
            string reversed = string.Empty;
            string password = Console.ReadLine();
            int counter = 0;

            for (int i = password.Length - 1; i >= 0; i--)
            {
                reversed += password[i];
            }

            string tryPass = string.Empty;

            while ((tryPass = Console.ReadLine()) != reversed)
            {
                if (counter < 3)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                    counter++;
                }
                else
                {
                    Console.WriteLine($"User {password} blocked!");
                    return;
                }
            }

            Console.WriteLine($"User {password} logged in.");
        }
    }
}
