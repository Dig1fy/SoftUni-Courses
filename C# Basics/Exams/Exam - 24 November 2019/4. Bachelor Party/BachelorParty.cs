using System;

namespace Exam24November2019
{
    class Program
    {
        static void Main()
        {
            int singerPayment = int.Parse(Console.ReadLine());
            string command = string.Empty;
            int smallGroups = 0;
            int bigGroups = 0;

            while ((command = Console.ReadLine()) != "The restaurant is full")
            {
                int groupsCount = int.Parse(command);

                if (groupsCount < 5)
                {
                    smallGroups += groupsCount;
                }
                else if (groupsCount >= 5)
                {
                    bigGroups += groupsCount;
                }
            }

            int totalAmount = smallGroups * 100 + bigGroups * 70;

            if (singerPayment <= totalAmount)
            {
                Console.WriteLine($"You have {bigGroups + smallGroups} guests and {totalAmount - singerPayment} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {bigGroups + smallGroups} guests and {totalAmount} leva income, but no singer.");
            }
        }
    }
}