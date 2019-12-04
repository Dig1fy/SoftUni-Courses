namespace MortalEngines.Factories
{
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using MortalEngines.Factories.Contracts;

    public class PilotFactory : IPilotFactory
    {
        public IPilot CreatePilot(string name)
        => new Pilot(name);
    }
}
