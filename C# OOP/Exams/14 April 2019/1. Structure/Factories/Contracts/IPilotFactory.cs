namespace MortalEngines.Factories.Contracts
{
    using MortalEngines.Entities.Contracts;

    public interface IPilotFactory
    {
        IPilot CreatePilot(string name);
    }
}
