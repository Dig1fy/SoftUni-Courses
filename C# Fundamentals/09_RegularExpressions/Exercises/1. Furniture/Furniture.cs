using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main()
        {
            var pattern = @">>([A-z]+)<<(\d+\.?\d*)!(\d+)";
            var command = string.Empty;
            var totalPrice = 0.0;
            var builder = new StringBuilder();

            while ((command = Console.ReadLine()) != "Purchase")
            {
                var matches = Regex.Matches(command, pattern);

                foreach (Match match in matches)
                {
                    var currentFurniture = match.Groups[1].Value;
                    builder.AppendLine(currentFurniture);
                    var currentPrice = match.Groups[2].Value;
                    var currentQy = match.Groups[3].Value;
                    totalPrice += double.Parse(currentPrice) * double.Parse(currentQy);
                }
            }

            builder.AppendLine($"Total money spend: {totalPrice:f2}");
            Console.WriteLine("Bought furniture:");
            Console.WriteLine(string.Join(Environment.NewLine, builder));
        }
    }
}
