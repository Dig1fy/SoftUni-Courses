using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main()
        {
            var pattern = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";
            
            var command = string.Empty;
            var builder = new StringBuilder();
            var totalIncome = 0.0;

            while ((command = Console.ReadLine()) != "end of shift")
            {
                var matches = Regex.Matches(command, pattern);

                foreach (Match match in matches)
                {
                    var name = match.Groups["name"].Value;
                    var product = match.Groups["product"].Value;
                    var count = int.Parse(match.Groups["count"].Value);
                    var priceMixed = match.Groups["price"].Value;
                    var priceString = string.Empty;

                    for (int i = 0; i < priceMixed.Length; i++)
                    {
                        if (char.IsDigit(priceMixed[i]) || priceMixed[i] == '.')
                        {
                            priceString += priceMixed[i];
                        }
                    }

                    var realPrice = double.Parse(priceString);
                    builder.AppendLine($"{name}: {product} - {count * realPrice:f2}");
                    totalIncome += (count * realPrice);
                }
            }

            builder.AppendLine($"Total income: {totalIncome:f2}");
            Console.WriteLine(string.Join(Environment.NewLine, builder));
        }
    }
}
