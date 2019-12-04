namespace MortalEngines.Factories
{
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using MortalEngines.Factories.Contracts;

    class TankFactory : ITankFactory
    {
        public ITank CreateTank(string name, double attack, double defense)
        => new Tank(name, attack, defense);
    }
}
