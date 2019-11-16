using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main()
        {
            double initialMoney = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsabrePrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double sabresTotal = (studentsCount + Math.Ceiling(studentsCount * 0.1)) * lightsabrePrice;
            double robesTotal = studentsCount * robePrice; ;
            double beltsTotal = 0;
            int beltCounter = 0;
            int studentCopy = studentsCount;

            for (int i = 1; i <= studentsCount; i++)
            {
                beltCounter++;

                if (beltCounter == 6)
                {
                    beltCounter = 0;
                    studentCopy--;
                }
            }

            beltsTotal = studentCopy * beltPrice;
            double totalAmount = beltsTotal + sabresTotal + robesTotal;

            if (totalAmount <= initialMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {totalAmount:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(totalAmount - initialMoney):f2}lv more.");
            }
        }
    }
}