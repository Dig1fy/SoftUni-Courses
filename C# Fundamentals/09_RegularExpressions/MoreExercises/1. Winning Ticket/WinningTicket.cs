using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class Program
    {
        static void Main()
        {
            var ticketsToCheck = Console.ReadLine()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.Trim())
                .ToArray();

            var winningTicket = false;

            foreach (var ticket in ticketsToCheck)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                var leftPart = new string(ticket.Take(10).ToArray());
                var rightPart = new string(ticket.Skip(10).ToArray());
                winningTicket = false;
                var winningSymbols = new string[] { "#", "@", "\\^", "\\$" };

                foreach (var winningSymbol in winningSymbols)
                {
                    var win = new Regex($"{winningSymbol}{{6,}}");
                    var leftPartMatch = win.Match(leftPart);

                    if (leftPartMatch.Success)
                    {
                        var rigtParthMatch = win.Match(rightPart);

                        if (rigtParthMatch.Success)
                        {
                            winningTicket = true;

                            var leftWinLenght = leftPartMatch.Value.Length;
                            var rightWinLenght = rigtParthMatch.Value.Length;

                            var jackpot = string.Empty;

                            if (leftWinLenght == 10 && rightWinLenght == 10)
                            {
                                jackpot = "Jackpot!";
                            }

                            Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(leftWinLenght, rightWinLenght)}{winningSymbol.Trim('\\')} {jackpot}");
                            break;
                        }
                    }
                }

                if (!winningTicket)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }
    }
}
