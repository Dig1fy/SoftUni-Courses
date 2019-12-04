namespace MortalEngines.Factories
{
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using MortalEngines.Factories.Contracts;

    public class FighterFactory : IFighterFactory
    {
        public IFighter CreateFighter(string name, double attack, double defense)
        => new Fighter(name, attack, defense);
    }
}
