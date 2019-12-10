namespace PlayersAndMonsters.Models.BattleFields
{
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            var listOfPlayers = new List<IPlayer>() { attackPlayer, enemyPlayer };

            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            foreach (var player in listOfPlayers)
            {
                if (player is Beginner)
                {
                    player.Health += 40;

                    player.CardRepository.Cards.ToList().ForEach(x => x.DamagePoints += 30);
                }
            }

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);

            while (true)
            {
                var attackerDamage = attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);
                var defenderDamage = enemyPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);

                enemyPlayer.TakeDamage(attackerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(defenderDamage);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
    }
}