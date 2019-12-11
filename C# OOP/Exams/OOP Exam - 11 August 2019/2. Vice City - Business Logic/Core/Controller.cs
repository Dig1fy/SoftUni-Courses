namespace ViceCity.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ViceCity.Core.Contracts;
    using ViceCity.Models.Guns;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Repositories.Contracts;

    public class Controller : IController
    {
        private IPlayer mainPlayer;
        private List<IPlayer> civilPlayers;
        private Queue<IGun> gunsQueue;
        private INeighbourhood neighbourhood;

        public Controller(IPlayer mainPlayer, INeighbourhood neighbourhood)
        {
            this.mainPlayer = mainPlayer;
            this.gunsQueue = new Queue<IGun>();
            this.neighbourhood = neighbourhood;

            this.civilPlayers = new List<IPlayer>();
        }
        public string AddGun(string type, string name)
        {
            IGun newGun;

            switch (type)
            {
                case "Pistol":
                    newGun = new Pistol(name);
                    break;
                case "Rifle":
                    newGun = new Rifle(name);
                    break;
                default:
                    newGun = null;
                    break;
            }

            if (newGun is null)
            {
                return "Invalid gun type!";
            }
            else
            {
                this.gunsQueue.Enqueue(newGun);
                return $"Successfully added {name} of type: {type}";
            }
        }

        public string AddGunToPlayer(string name)
        {
            if (gunsQueue.Count == 0)
            {
                return $"There are no guns in the queue!";
            }

            if (name == "Vercetti")
            {
                var gunName = gunsQueue.Peek();
                this.mainPlayer.GunRepository.Add(gunsQueue.Dequeue());
                return $"Successfully added {gunName.Name} to the Main Player: Tommy Vercetti";
            }
            if (!this.civilPlayers.Any(x => x.Name == name))
            {
                return "Civil player with that name doesn't exists!";
            }

            var newGunName = gunsQueue.Peek();
            var newGun = gunsQueue.Dequeue();
            var player = this.civilPlayers.Find(x => x.Name == name);

            player.GunRepository.Add(newGun);
            return $"Successfully added {newGunName.Name} to the Civil Player: {player.Name}";
        }

        public string AddPlayer(string name)
        {
            var newCivilPlayer = new CivilPlayer(name);
            this.civilPlayers.Add(newCivilPlayer);
            return $"Successfully added civil player: {newCivilPlayer.Name}!";
        }

        public string Fight()
        {
            this.neighbourhood.Action(mainPlayer, civilPlayers);

            if (mainPlayer.LifePoints == 100 && !civilPlayers.Any(x => x.LifePoints != 50))
            {
                return "Everything is okay!";
            }

            var deadPlayers = civilPlayers.Where(x => !x.IsAlive).Count();
            this.civilPlayers.RemoveAll(x => !x.IsAlive);
            var alivePlayers = civilPlayers.Count;

            var sb = new StringBuilder();

            sb.AppendLine("A fight happened:");
            sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
            sb.AppendLine($"Tommy has killed: {deadPlayers} players!");
            sb.AppendLine($"Left Civil Players: {alivePlayers}!");

            return sb.ToString().TrimEnd();
        }
    }
}
