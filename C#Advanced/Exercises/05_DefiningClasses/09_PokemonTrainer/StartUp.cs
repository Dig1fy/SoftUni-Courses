namespace PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class StartUp
    {
        static void Main(string[] args)
        {
            var command = string.Empty;
            var allTrainers = new Dictionary<string, Trainer>();

            while ((command = Console.ReadLine()) != "Tournament")
            {
                var inputInfo = command.Split()
                    .ToList();
                var trainerName = inputInfo[0];
                var pokemonName = inputInfo[1];
                var pokemonElement = inputInfo[2];
                var pokemonHealth = int.Parse(inputInfo[3]);

                if (!allTrainers.ContainsKey(trainerName))
                {
                    allTrainers.Add(trainerName, new Trainer(trainerName));
                }

                Trainer currentTrainer = allTrainers[trainerName];
                var currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                currentTrainer.Pokemons.Add(currentPokemon);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                CheckForCurrentElement(command, allTrainers);
            }

            foreach (var trainer in allTrainers.OrderByDescending(x => x.Value.Badges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.Pokemons.Count}");
            }
        }

        private static void CheckForCurrentElement(string command, Dictionary<string, Trainer> allTrainers)
        {
            foreach (var trainerr in allTrainers.Values)
            {
                if (trainerr.Pokemons.Any(x => x.Element == command))
                {
                    trainerr.Badges++;
                }
                else
                {
                    RemoveDeadPokemons(trainerr);
                }
            }
        }

        private static void RemoveDeadPokemons(Trainer trainerr)
        {
            foreach (var pokemonn in trainerr.Pokemons)
            {
                pokemonn.Health -= 10;
            }

            trainerr.Pokemons.RemoveAll(x => x.Health <= 0);
        }
    }
}
