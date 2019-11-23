using System;

namespace ExamOn09And10March2019
{
    class Program
    {
        static void Main()
        {
            string playerOneName = Console.ReadLine();
            string playerTwoName = Console.ReadLine();

            int playerOnePoints = 0;
            int playerTwoPoints = 0;
            string winner = "";
            bool numberWars = false;
            int winnerPoints = 0;
            string cardPlayerOne = "";
            string cardPlayerTwo = "";
            bool endOfGame = false;

            while (playerOneName != "End of game" || playerTwoName != "End of game")
            {
                cardPlayerOne = Console.ReadLine();
                if (cardPlayerOne == "End of game")
                {
                    endOfGame = true;
                    break;
                }
                cardPlayerTwo = Console.ReadLine();
                if (cardPlayerTwo == "End of game")
                {
                    endOfGame = true;
                    break;
                }
                if (cardPlayerOne == cardPlayerTwo)
                {
                    numberWars = true;
                    cardPlayerOne = Console.ReadLine();
                    cardPlayerTwo = Console.ReadLine();
                    if (int.Parse(cardPlayerOne) > int.Parse(cardPlayerTwo))
                    {
                        winner = playerOneName;
                        winnerPoints = playerOnePoints;
                        break;
                    }
                    else
                    {
                        winner = playerTwoName;
                        winnerPoints = playerTwoPoints;
                        break;
                    }
                }
                else if (int.Parse(cardPlayerOne) > int.Parse(cardPlayerTwo))
                {
                    playerOnePoints += int.Parse(cardPlayerOne) - int.Parse(cardPlayerTwo);
                }
                else if (int.Parse(cardPlayerTwo) > int.Parse(cardPlayerOne))
                {
                    playerTwoPoints += (int.Parse(cardPlayerTwo) - int.Parse(cardPlayerOne));
                }
            }

            if (numberWars == true)
            {
                Console.WriteLine("Number wars!");
                Console.WriteLine($"{winner} is winner with {winnerPoints} points");
            }

            if (endOfGame == true)
            {
                Console.WriteLine($"{playerOneName} has {playerOnePoints} points");
                Console.WriteLine($"{playerTwoName} has {playerTwoPoints} points");
            }
        }
    }
}