using System;

namespace WhileLoop
{
    class Program
    {
        static void Main()
        {
            double vacationMoney = double.Parse(Console.ReadLine());
            double currentMoney = double.Parse(Console.ReadLine());

            int daysCounter = 0;
            int spendCounter = 0; 

            while (currentMoney < vacationMoney)
            {
                if (spendCounter >= 5)
                {
                    break;
                }

                daysCounter++;
                string saveSpend = Console.ReadLine();
                double moneySpendSave = double.Parse(Console.ReadLine());

                if (saveSpend == "spend")
                {
                    currentMoney -= moneySpendSave;

                    if (currentMoney - moneySpendSave < 0)
                    {
                        currentMoney = 0;
                    }

                    spendCounter++;
                }
                else if (saveSpend == "save")
                {
                    currentMoney += moneySpendSave;
                    spendCounter = 0;
                }
            }

            if (spendCounter == 5)
            {
                Console.WriteLine($"You can't save the money.");
                Console.WriteLine(daysCounter);
            }
            else
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }
        }
    }
}