using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        private const int statsMinValue = 0;
        private const int statsMaxValue = 100;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get { return name; }
            private set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value; 
            }
        }

        public int Endurance
        {
            get { return endurance; }
            private set
            {
                ValidateTheCurrentStat("Endurance", value);
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get { return sprint; }
            private set
            {
                ValidateTheCurrentStat("Sprint", value);
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get { return dribble; }
            private set
            {
                ValidateTheCurrentStat("Dribble", value);
                this.dribble = value;
            }
        }

        public int Passing
        {
            get { return passing; }
            private set
            {
                ValidateTheCurrentStat("Passing", value);
                this.passing = value;
            }
        }

        public int Shooting
        {
            get { return shooting; }
            private set 
            {
                ValidateTheCurrentStat("Shooting", value);
                this.shooting = value;
            }
        }

        private void ValidateTheCurrentStat(string propertyName, int value)
        {
            if (value < statsMinValue || value > statsMaxValue)
            {
                throw new ArgumentException($"{propertyName} should be between 0 and 100.");
            }
        }

        public int GetPlayersAverageStats()
        {
            var allStats = this.Endurance + this.Shooting + this.Passing + this.Sprint + this.Dribble;
            return (int)Math.Round(allStats/ 5.0);
        }
    }
}
