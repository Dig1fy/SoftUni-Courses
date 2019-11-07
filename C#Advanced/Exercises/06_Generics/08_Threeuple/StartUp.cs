namespace Tuple
{
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .ToArray();

                switch (i)
                {
                    case 0:
                        var name = input[0] + " " + input[1];
                        var adress = input[2];
                        var city = input[3];
                        var firstTuple = new Tuple<string, string, string>(name, adress, city);
                        Console.WriteLine(firstTuple);
                        break;
                    case 1:
                        var name2 = input[0];
                        var litresOfBeer = int.Parse(input[1]);
                        var drunkOrNot = false;
                        var drunkOrNotInput = input[2];

                        if (drunkOrNotInput == "drunk")
                        {
                            drunkOrNot = true;
                        }

                        var secondTuple = new Tuple<string, int, bool>(name2, litresOfBeer, drunkOrNot);
                        Console.WriteLine(secondTuple);
                        break;
                    case 2:

                        var name3 = input[0];
                        var bancAccount = double.Parse(input[1]);
                        var bankName = input[2];
                        var thirdTuple = new Tuple<string, double, string>(name3, bancAccount, bankName);
                        Console.WriteLine(thirdTuple);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
