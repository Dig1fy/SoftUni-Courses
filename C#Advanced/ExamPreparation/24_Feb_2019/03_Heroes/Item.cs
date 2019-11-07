namespace Heroes
{
    using System.Text;

    public class Item
    {
        public Item(int strength, int ability, int intelligence)
        {
            Strength = strength;
            Ability = ability;
            Intelligence = intelligence;
            var sb = new StringBuilder();
        }

        public int Strength { get; set; }
        public int Ability { get; set; }
        public int Intelligence { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Item:");
            stringBuilder.AppendLine($"  * Strength: {Strength}");
            stringBuilder.AppendLine($"  * Ability {Ability}");
            stringBuilder.AppendLine($"  * Intelligence {Intelligence}");

            return stringBuilder.ToString();
        }
    }
}
