namespace MortalEngines.Commands
{
    public interface ICommandInterpreter
    {
        Command Interpret(string input);
    }
}
