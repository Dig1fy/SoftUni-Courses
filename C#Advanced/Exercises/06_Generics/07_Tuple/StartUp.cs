namespace Tuple
{
    using System;
    using System.Linq;

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
                        var firstTuple = new Tuple<string, string>(name, adress);
                        Console.WriteLine(firstTuple);
                        break;
                    case 1:
                        var name2 = input[0];
                        var litresOfBeer = int.Parse(input[1]);
                        var secondTuple = new Tuple<string, int>(name2, litresOfBeer);
                        Console.WriteLine(secondTuple);
                        break;
                    case 2:
                        var intNum = int.Parse(input[0]);
                        var doubleNum = double.Parse(input[1]);
                        var thirdTuple = new Tuple<int, double>(intNum, doubleNum);
                        Console.WriteLine(thirdTuple);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
