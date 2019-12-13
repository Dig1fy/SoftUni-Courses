namespace AnimalCentre.Models.Hotel
{
    using AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Hotel : IHotel
    {
        private int capacity ;
        private Dictionary<string, IAnimal> animals;
        
        public Hotel()
        {
            this.capacity = 10;
            this.animals = new Dictionary<string, IAnimal>();          
        }
        public int Capacity => capacity;

        public IReadOnlyDictionary<string,IAnimal> Animals 
            => new ReadOnlyDictionary<string, IAnimal>(this.animals);

        
        public void Accommodate(IAnimal animal)
        {
            if (Capacity <= 0)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            if (Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals.Add(animal.Name, animal);
            capacity--;
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            var adoptedAnimal = this.animals.First(x => x.Value.Name == animalName);
            adoptedAnimal.Value.IsAdopt = true;
            adoptedAnimal.Value.Owner = owner;
            animals.Remove(adoptedAnimal.Key);
        }
    }
}
