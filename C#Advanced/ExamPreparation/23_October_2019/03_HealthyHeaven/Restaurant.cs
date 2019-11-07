namespace HealthyHeaven
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Restaurant
    {
        public string Name { get; set; }
        private List<Salad> data;

        public Restaurant(string name)
        {
            Name = name;
            data = new List<Salad>();
        }

        public void Add(Salad salad)
        {
            data.Add(salad);
        }

        public bool Buy(string name)
        {
            foreach (var salad in data)
            {
                if (salad.Name.Equals(name))
                {
                    data.Remove(salad);
                    return true;
                }
            }

            return false;
        }

        public Salad GetHealthiestSalad()
        {
            return data.OrderBy(x => x.GetTotalCalories()).First();      
        }

        public string GenerateMenu()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} have {data.Count} salads:");

            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}
