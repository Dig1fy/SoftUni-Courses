using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Commands.Contracts
{
    public interface ICommandInterpreter
    {
        string Interpret(string[] commandArgs, IManagerController managerController);
    }
}
