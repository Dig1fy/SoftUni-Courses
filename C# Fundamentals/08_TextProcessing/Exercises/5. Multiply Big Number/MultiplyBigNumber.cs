using System;
using System.Linq;
using System.Text;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main()
        {
            var firstNum = Console.ReadLine();
            var multiplier = int.Parse(Console.ReadLine());
            var onMind = 0;
            var stringBuilder = new StringBuilder();

            for (int i = firstNum.Length - 1; i >= 0; i--)
            {
                var lastDigit = int.Parse(firstNum[i].ToString());
                var result = lastDigit * multiplier + onMind;
                stringBuilder.Append(result % 10);
                onMind = result / 10;
            }

            if (onMind != 0)
            {
                stringBuilder.Append(onMind);
            }

            var resultT = string.Join("", stringBuilder.ToString().Reverse()).TrimStart('0');

            if (resultT == string.Empty)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(resultT);
            }
        }
    }
}
