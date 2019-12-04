namespace MortalEngines.Commands
{
    public interface ICommand
    {
        string Name { get; }

        string[] Arguments { get; }
    }
}
