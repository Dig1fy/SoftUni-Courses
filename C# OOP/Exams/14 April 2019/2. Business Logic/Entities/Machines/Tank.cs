using MortalEngines.Entities.Contracts;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Tank : BaseMachine, ITank
    {
        private const double HEALTH_POINTS = 100;
        private const double DEFENSE_MODE_ATTACK = 40;
        private const double DEFENSE_MODE_DEFENSE = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, HEALTH_POINTS, attackPoints - DEFENSE_MODE_ATTACK, defensePoints + DEFENSE_MODE_DEFENSE)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }
        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;
                this.AttackPoints += DEFENSE_MODE_ATTACK;
                this.DefensePoints -= DEFENSE_MODE_DEFENSE;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints -= DEFENSE_MODE_ATTACK;
                this.DefensePoints += DEFENSE_MODE_DEFENSE;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            sb.AppendLine($" *Defense: { (this.DefenseMode ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
