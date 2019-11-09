namespace PlayersAndMonsters
{
    public class Hero
    {
        public Hero(string name, int level)
        {
            this.Username = name;
            this.Level = level;
        }
        public Hero(string name)
        {
            this.Username = name;
        }

        public string Username { get; set; }
        public int Level { get; set; }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
