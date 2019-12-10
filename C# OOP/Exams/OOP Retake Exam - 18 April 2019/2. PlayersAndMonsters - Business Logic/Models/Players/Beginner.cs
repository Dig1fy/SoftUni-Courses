namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Repositories.Contracts;

    public class Beginner : Player
    {
        private const int InitialHealthPoints = 50;
        public Beginner(ICardRepository cardRepository, string userName) 
            : base(cardRepository, userName, InitialHealthPoints)
        {
        }
    }
}
