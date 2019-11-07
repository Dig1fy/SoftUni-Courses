namespace Heroes
{
    using System.Text;

    public class Hero
    {
        public Hero(string name, int level, Item item)
        {
            Name = name;
            Level = level;
            Item = item;
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item{ get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Hero: {Name} - {Level}lvl");
            stringBuilder.AppendLine($"Item:");
            stringBuilder.AppendLine($"Strength: {Item.Strength}");
            stringBuilder.AppendLine($"Ability: {Item.Ability}");
            stringBuilder.AppendLine($"Intelligence: {Item.Intelligence}");
            return stringBuilder.ToString();
        }
    }
}
