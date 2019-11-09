using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
        }

        private int GetTeamRating()
        {
            var total = 0;

            foreach (var player in players)
            {
                total += player.GetPlayersAverageStats();
            }

            return (int)Math.Round(total/(double)players.Count);
        }
        
        public override string ToString()
        {
            if (this.players.Count==0)
            {
                return $"{this.Name} - 0";
            }
            return $"{this.Name} - {GetTeamRating()}";
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName, string teamName)
        {
            var wantedPlayer = players.Where(x => x.Name.Equals(playerName)).FirstOrDefault();

            if (wantedPlayer == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
            }

            players.Remove(wantedPlayer);
        }
    }
}
