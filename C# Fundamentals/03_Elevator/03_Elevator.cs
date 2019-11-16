using System;

namespace Elevator
{
    class Program
    {
        static void Main()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());

            int courses = (numberOfPeople / elevatorCapacity);

            if (numberOfPeople % elevatorCapacity != 0)
            {
                courses++;
            }

            Console.WriteLine(courses);
        }
    }
}