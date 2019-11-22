using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMANDNAME_POSTFIX = "Command";

        public string Read(string inputArguments)
        {
            var args = inputArguments
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var commandName = (args[0] + COMMANDNAME_POSTFIX).ToLower();
            var commandArgs = args
                .Skip(1)
                .ToArray();


            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == commandName);

            if (type == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand instanceType = Activator.CreateInstance(type) as ICommand;

            if (instanceType is null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            var result = instanceType.Execute(commandArgs);

            return result;
        }
    }
}

