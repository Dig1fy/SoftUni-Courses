﻿namespace PlayersAndMonsters.Core.Factories
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            IPlayer player;

            switch (type)
            {
                case "Beginner":
                    player = new Beginner(new CardRepository(), username);
                    break;
                case "Advanced":
                    player = new Advanced(new CardRepository(), username);
                    break;
                default:
                    player = null;
                    break;
            }

            return player;
        }
    }
}
