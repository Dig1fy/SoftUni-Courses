using System;

namespace NestedConditionalStatements
{
    class Program
    {
        static void Main()
        {
            int hourOfExam = int.Parse(Console.ReadLine());
            int minutesOfExam = int.Parse(Console.ReadLine());
            int hourOfArrival = int.Parse(Console.ReadLine());
            int minutesOfArrival = int.Parse(Console.ReadLine());

            int convertedExam = hourOfExam * 60 + minutesOfExam;
            int convertedArrival = hourOfArrival * 60 + minutesOfArrival;

            string mmAfterTheStart = " minutes after the start";
            string mmBeforeTheStart = " minutes before the start";
            string hhAfterTheStart = " hours after the start";
            string hhBeforeTheStart = " hours before the start";
            string onTime = "On time";
            string status = "";
            string status2 = "";

            //late
            if (convertedArrival > convertedExam)
            {
                status2 = "Late";
                if ((convertedArrival - convertedExam) >= 60)
                {
                    status = hhAfterTheStart;
                    if ((convertedArrival - convertedExam) % 60 < 10)
                    {
                        Console.WriteLine(status2);
                        Console.WriteLine($"{(convertedArrival - convertedExam) / 60}:0{(convertedArrival - convertedExam) % 60}{hhAfterTheStart}");
                    }
                    else
                    {
                        Console.WriteLine(status2);
                        Console.WriteLine($"{(convertedArrival - convertedExam) / 60}:{(convertedArrival - convertedExam) % 60}{hhAfterTheStart}");
                    }
                }
                else if (convertedArrival - convertedExam < 60)
                {
                    Console.WriteLine(status2);
                    status = mmAfterTheStart;
                    Console.WriteLine($"{(convertedArrival - convertedExam) % 60}{mmAfterTheStart}");
                }
            } //on time exact
            else if (convertedExam == convertedArrival)

            {
                status = onTime;
                Console.WriteLine(status);
            }//on time <30 min
            else if ((convertedExam - convertedArrival) <= 30)
            {
                status2 = onTime;
                status = mmBeforeTheStart;
                Console.WriteLine(status2);
                Console.WriteLine($"{convertedExam - convertedArrival}{mmBeforeTheStart}");
            }
            //early >30
            else if ((convertedExam - convertedArrival) > 30)
            {
                status2 = "Early";
                if ((convertedExam - convertedArrival) < 60)
                {
                    status = mmBeforeTheStart;
                    Console.WriteLine(status2);
                    Console.WriteLine($"{convertedExam - convertedArrival}{status}");
                }
                else if ((convertedExam - convertedArrival) >= 60)
                {
                    status2 = "Early";
                    if ((convertedExam - convertedArrival) % 60 < 10)
                    {
                        Console.WriteLine(status2);
                        Console.WriteLine($"{(convertedExam - convertedArrival) / 60}:0{(convertedExam - convertedArrival) % 60}{hhBeforeTheStart}");
                    }
                    else if ((convertedExam - convertedArrival) % 60 >= 10)
                    {
                        Console.WriteLine(status2);
                        Console.WriteLine($"{(convertedExam - convertedArrival) / 60}:{(convertedExam - convertedArrival) % 60}{hhBeforeTheStart}");
                    }
                }
            }
        }
    }
}