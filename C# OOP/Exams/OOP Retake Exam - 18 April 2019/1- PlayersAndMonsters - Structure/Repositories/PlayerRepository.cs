namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayerRepository : IPlayerRepository
    {
        private List<IPlayer> listOfPlayers;

        public PlayerRepository()
        {
            this.listOfPlayers = new List<IPlayer>();
        }

        public int Count => this.listOfPlayers.Count;

        public IReadOnlyCollection<IPlayer> Players
            => this.listOfPlayers.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player is null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (this.listOfPlayers.Any(x => x.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.listOfPlayers.Add(player);
        }

        public IPlayer Find(string username)
            => this.listOfPlayers.Find(x => x.Username == username);

        public bool Remove(IPlayer player)
        {
            if (player is null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            return this.listOfPlayers.Remove(player);
        }
    }
}