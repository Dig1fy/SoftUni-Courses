using System;

namespace ConditionalStatements
{
    class Program
    {
        static void Main()
        {
            int startHour = int.Parse(Console.ReadLine());
            int startMinutes = int.Parse(Console.ReadLine());

            int timeInMinutes = startHour * 60 + startMinutes;
            int timeIn15Minutes = timeInMinutes + 15;

            int finalHour = timeIn15Minutes / 60;
            int finalMinutes = timeIn15Minutes % 60;

            if (finalHour > 23)
            {
                finalHour -= 24;
            }

            if (finalMinutes >= 0 && finalMinutes < 10)
            {
                Console.WriteLine($"{finalHour}:0{finalMinutes}");
            }
            else if (finalMinutes >= 10)
            {
                Console.WriteLine($"{finalHour}:{finalMinutes}");
            }
        }
    }
}