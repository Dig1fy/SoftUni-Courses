namespace PlayersAndMonsters.Commands
{
    using PlayersAndMonsters.Commands.Contracts;
    using PlayersAndMonsters.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Interpret(string[] commandArgs, IManagerController managerController)
        {
            var message = string.Empty;
            var command = commandArgs[0];

            switch (command)
            {
                case "AddPlayer":
                    message = managerController.AddPlayer(commandArgs[1], commandArgs[2]);
                    break;
                case "AddCard":
                    message = managerController.AddCard(commandArgs[1], commandArgs[2]);
                    break;
                case "AddPlayerCard":
                    message = managerController.AddPlayerCard(commandArgs[1], commandArgs[2]);
                    break;
                case "Fight":
                    message = managerController.Fight(commandArgs[1], commandArgs[2]);
                    break;
                case "Report":
                    message = managerController.Report();
                    break;
                default:
                    message = null;
                    break;
            }

            return message;
        }
    }
}
