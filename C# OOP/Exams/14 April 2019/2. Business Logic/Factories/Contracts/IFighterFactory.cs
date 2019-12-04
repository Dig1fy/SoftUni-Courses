namespace MortalEngines.Factories.Contracts
{
    using MortalEngines.Entities.Contracts;

    public interface IFighterFactory
    {
        IFighter CreateFighter(string name, double attack, double defense);
    }
}
