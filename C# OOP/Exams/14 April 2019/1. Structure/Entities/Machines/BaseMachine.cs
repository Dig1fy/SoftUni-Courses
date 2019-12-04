namespace MortalEngines.Entities.Machines
{
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private readonly List<string> targets;

        protected BaseMachine(string name, double healthPoints, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;

            this.targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IReadOnlyCollection<string> Targets
            => this.targets.AsReadOnly();
        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                this.pilot = value ?? throw new NullReferenceException("Pilot cannot be null.");
            }

        }

        public void Attack(IMachine target)
        {
            if (target is null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            var attackDamage = this.AttackPoints - target.DefensePoints;
            target.HealthPoints -= attackDamage;

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }

            this.targets.Add(target.Name);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints:F2}");
            sb.AppendLine($" *Attack: {this.AttackPoints:F2}");
            sb.AppendLine($" *Defense: {this.DefensePoints:F2}");
            sb.Append(" *Targets: ");

            if ( this.Targets is null || this.Targets.Count == 0)
            {
                sb.AppendLine("None");
            }
            else
            {
                sb.AppendLine(string.Join(",", this.Targets));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
