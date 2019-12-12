namespace SpaceStation.Models.Mission
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (true)
            {
                var currentAstronaut = astronauts.FirstOrDefault(x => x.CanBreath);

                if (currentAstronaut is null)
                {
                    break;
                }

                var currentItem = planet.Items.FirstOrDefault();

                if (currentItem is null)
                {
                    break;
                }

                currentAstronaut.Breath();

                currentAstronaut.Bag.Items.Add(currentItem);
                planet.Items.Remove(currentItem);
            }
        }
    }
}
