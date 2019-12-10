namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Repositories.Contracts;

    public class Advanced : Player
    {
        private const int InitialHealthPoints = 250;
        public Advanced(ICardRepository cardRepository, string userName) 
            : base(cardRepository, userName, InitialHealthPoints)
        {
        }
    }
}
