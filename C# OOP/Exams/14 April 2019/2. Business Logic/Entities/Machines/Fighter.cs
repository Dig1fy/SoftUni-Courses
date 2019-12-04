using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double HEALTH_POINTS = 200;
        private const double AGGRESSIVE_MODE_ATTACKPOINTS = 50;
        private const double AGGRESSIVE_MODE_DEFENSEPOINTS = 25;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, HEALTH_POINTS, attackPoints + AGGRESSIVE_MODE_ATTACKPOINTS,
                  defensePoints - AGGRESSIVE_MODE_DEFENSEPOINTS)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode)
            {
                this.AggressiveMode = false;
                this.HealthPoints -= AGGRESSIVE_MODE_ATTACKPOINTS;
                this.DefensePoints += AGGRESSIVE_MODE_DEFENSEPOINTS;
            }
            else
            {
                this.AggressiveMode = true;
                this.HealthPoints += AGGRESSIVE_MODE_ATTACKPOINTS;
                this.DefensePoints -= AGGRESSIVE_MODE_DEFENSEPOINTS;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            sb.AppendLine($" *Aggressive: {(this.AggressiveMode ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }       
    }
}
