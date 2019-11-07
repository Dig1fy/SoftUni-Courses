namespace Heroes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public void Add(Hero hero)
        {
            data.Add(hero);
        }

        public int Count { get => data.Count; }

        public void Remove(string name)
        {
            data = data.Where(x => x.Name != name).ToList();
        }

        public Hero GetHeroWithHighestStrength()
        {
            var highestStrength = data.OrderByDescending(x => x.Item.Strength).First();
            return highestStrength;
        }

        public Hero GetHeroWithHighestAbility()
        {
            var highestAbility = data.OrderByDescending(x => x.Item.Ability).First();
            return highestAbility;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            var highestIntelligence = data.OrderByDescending(x => x.Item.Intelligence).First();
            return highestIntelligence;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var hero in data)
            {
                sb.AppendLine($"{hero}");
            }

            return sb.ToString();
        }
    }
}
