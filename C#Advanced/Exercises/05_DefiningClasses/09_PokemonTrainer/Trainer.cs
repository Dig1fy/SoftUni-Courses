namespace PokemonTrainer
{
    using System.Collections.Generic;

    class Trainer
    {
        private string name;
        private int badges;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Badges
        {
            get { return badges; }
            set { badges = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }




    }
}
