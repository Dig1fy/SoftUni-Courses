using System;

namespace ExamOn09And10March2019
{
    class Program
    {
        static void Main()
        {
            string partOfChampionship = Console.ReadLine();
            string typeTicket = Console.ReadLine();
            int numberoftickets = int.Parse(Console.ReadLine());
            char photo = char.Parse(Console.ReadLine());
            double ticketPrice = 0;

            if (partOfChampionship == "Quarter final")
            {
                if (typeTicket == "Standard")
                {
                    ticketPrice = 55.50;
                }
                else if (typeTicket == "Premium")
                {
                    ticketPrice = 105.20;
                }
                else if (typeTicket == "VIP")
                {
                    ticketPrice = 118.90;
                }
            }
            else if (partOfChampionship == "Semi final")
            {
                if (typeTicket == "Standard")
                {
                    ticketPrice = 75.88;
                }
                else if (typeTicket == "Premium")
                {
                    ticketPrice = 125.22;
                }
                else if (typeTicket == "VIP")
                {
                    ticketPrice = 300.40;
                }
            }
            else if (partOfChampionship == "Final")
            {
                if (typeTicket == "Standard")
                {
                    ticketPrice = 110.10;
                }
                else if (typeTicket == "Premium")
                {
                    ticketPrice = 160.66;
                }
                else if (typeTicket == "VIP")
                {
                    ticketPrice = 400;
                }
            }

            double totalMoney = ticketPrice * numberoftickets;

            if (totalMoney > 4000)
            {
                totalMoney = totalMoney * 0.75;
                photo = 'N';
            }
            else if (totalMoney > 2500)
            {
                totalMoney = totalMoney * 0.9;
            }
            if (photo == 'Y')
            {
                totalMoney = totalMoney + numberoftickets * 40;
            }

            Console.WriteLine($"{totalMoney:f2}");
        }
    }
}