namespace SpaceStationRecruitment
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Astronaut>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => this.data.Count();

        public void Add(Astronaut astronaut)
        {
            if (this.Count<Capacity)
            {
                data.Add(astronaut);
            }
        }
        public bool Remove(string name)
        {
            foreach (var person in data)
            {
                if (person.Name == name)
                {
                    data.Remove(person);
                    return true;
                }
            }

            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            return data.OrderByDescending(x => x.Age).First();
        }

        public Astronaut GetAstronaut(string name)
        {
            return data.Where(x => x.Name == name).First();
        }

        public string Report()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in data)
            {
                stringBuilder.AppendLine(astronaut.ToString());
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
