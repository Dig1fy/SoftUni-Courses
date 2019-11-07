namespace FightingArena
{
    using System.Collections.Generic;
    using System.Linq;

    public class Arena
    {
        private List<Gladiator> gladiators;

        public string Name { get; set; }
        public int Count => this.gladiators.Count();
        public Arena(string name)
        {
            this.Name = name;
            gladiators = new List<Gladiator>();
        }

        public void Add(Gladiator gladiator)
        {            
            gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
           gladiators = gladiators.Where(x => x.Name != name).ToList();            
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            return gladiators.OrderByDescending(x => x.GetStatPower()).First();
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            return gladiators.OrderByDescending(x => x.GetWeaponPower()).First();
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            return gladiators.OrderByDescending(x => x.GetTotalPower()).First();
        }

        public override string ToString()
        {
            return $"{this.Name} - {gladiators.Count} gladiators are participating.";
        }
    }
}
