namespace ViceCity.Models.Neghbourhoods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (true)
            {
                var currentGun = mainPlayer.GunRepository.Models.FirstOrDefault(x => x.CanFire);

                if (currentGun is null)
                {
                    break;
                }

                var currentCivilPlayer = civilPlayers.FirstOrDefault(x => x.IsAlive);

                if (currentCivilPlayer is null)
                {
                    break;
                }

                var takenLifePoints = currentGun.Fire();
                currentCivilPlayer.TakeLifePoints(takenLifePoints);
            }

            while (true)
            {
                var currentCivilPlayer = civilPlayers.FirstOrDefault(x => x.IsAlive);

                if (currentCivilPlayer is null)
                {
                    break;
                }

                var civilPlayerGun = currentCivilPlayer.GunRepository.Models.FirstOrDefault(x => x.CanFire);

                if (civilPlayerGun is null)
                {
                    break;
                }

                var damage = civilPlayerGun.Fire();
                mainPlayer.TakeLifePoints(damage);

                if (!mainPlayer.IsAlive)
                {
                    break;
                }
            }
        }
    }
}