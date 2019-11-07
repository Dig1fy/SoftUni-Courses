namespace AquariumAdventure
{
    using System.Text;

    public class Fish
    {
        public Fish(string name, string color, int fins)
        {
            Name = name;
            Color = color;
            Fins = fins;
        }

        public string Name { get; set; }
        public string Color { get; set; }
        public int Fins { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Fish: {this.Name}");
            sb.AppendLine($"Color: {this.Color}");
            sb.AppendLine($"Number of fins: {this.Fins}");
            return sb.ToString().Trim();
        }
    }
}
