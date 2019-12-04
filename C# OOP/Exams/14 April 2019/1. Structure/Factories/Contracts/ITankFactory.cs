namespace MortalEngines.Factories.Contracts
{
    using MortalEngines.Entities.Contracts;

    public interface ITankFactory
    {
        ITank CreateTank(string name, double attack, double defense);
    }
}
