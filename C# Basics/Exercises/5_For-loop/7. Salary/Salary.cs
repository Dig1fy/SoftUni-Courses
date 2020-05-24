using System;

namespace ForLoop
{
    class Program
    {
        static void Main()
        {
            int tabsCount = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            int facebookFee = 150;
            int instagramFee = 100;
            int redditFee = 50;

            for (int i = 0; i < tabsCount; i++)
            {
                string site = Console.ReadLine();

                if (site == "Facebook")
                {
                    salary -= facebookFee;
                }
                else if (site == "Instagram")
                {
                    salary -= instagramFee;
                }
                else if (site == "Reddit")
                {
                    salary -= redditFee;
                }
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }

            if (salary > 0)
            {
                Console.WriteLine(salary);
            }
        }
    }
}