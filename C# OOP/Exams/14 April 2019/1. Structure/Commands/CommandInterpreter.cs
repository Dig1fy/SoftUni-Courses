using System.Linq;

namespace MortalEngines.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public Command Interpret(string input)
        {
            var args = input.Split().ToArray();

            var commandName = args[0];
            var commandArgs = args.Skip(1).ToArray();

            return new Command(commandName, commandArgs);
        }
    }
}
