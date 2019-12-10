namespace PlayersAndMonsters.Core
{
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private ICardRepository cardRepository;
        private IPlayerRepository playerRepository;
        private IBattleField battleField;
        private ICardFactory cardFactory;
        private IPlayerFactory playerFactory;
        public ManagerController(ICardRepository cardRepository
            , IPlayerRepository playerRepository
            , IBattleField battleField
            , ICardFactory cardFactory
            , IPlayerFactory playerFactory)
        {
            this.cardRepository = cardRepository;
            this.playerRepository = playerRepository;
            this.battleField = battleField;
            this.playerFactory = playerFactory;
            this.cardFactory = cardFactory;
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var desiredCard = this.cardRepository.Find(cardName);
            var desiredPlayer = this.playerRepository.Find(username);

            desiredPlayer.CardRepository.Add(desiredCard);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = this.playerRepository.Players.FirstOrDefault(x => x.Username == attackUser);
            var enemy = this.playerRepository.Players.FirstOrDefault(x => x.Username == enemyUser);

            this.battleField.Fight(attacker, enemy);

            return $"Attack user health {attacker.Health} - Enemy user health {enemy.Health}";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine(player.ToString());

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(card.ToString());
                }

                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
