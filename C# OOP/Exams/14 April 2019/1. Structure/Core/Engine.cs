using MortalEngines.Commands;
using MortalEngines.Core.Contracts;
using MortalEngines.Entities.Machines;
using MortalEngines.IO.Contracts;
using System;

namespace MortalEngines
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IMachinesManager machinesManager;

        public Engine(
            IReader reader
            , IWriter writer
            , ICommandInterpreter commandInterpreter
            , IMachinesManager machinesManager)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;
            this.machinesManager = machinesManager;
        }

        public void Run()
        {
            var input = reader.Read();

            var endCommand = "Quit";

            while (input!= endCommand)
            {
                try
                {
                    var currentCommand = commandInterpreter.Interpret(input);
                    ExecuteCommand(currentCommand);
                }
                catch (ArgumentNullException ane)
                {
                    writer.Write($"Error: {ane.Message}");
                }
                catch (NullReferenceException nre)
                {
                    writer.Write($"Error: {nre.Message}");
                }
                //catch (Exception ex)
                //{
                //    writer.Write($"Error: {ex.Message} ");
                //}

                input = reader.Read();
            }
        }

        private void ExecuteCommand(Command currentCommand)
        {
            var commandName = currentCommand.Name;
            var unitName = currentCommand.Arguments[0];
            var message = string.Empty;

            switch (commandName)
            {
                case "HirePilot":
                    message = this.machinesManager.HirePilot(unitName);
                    break;
                case "PilotReport":
                    message = this.machinesManager.PilotReport(unitName);
                    break;
                case "ManufactureTank":
                    var attackPoints = double.Parse(currentCommand.Arguments[1]);
                    var defensePoints = double.Parse(currentCommand.Arguments[2]);
                    message = this.machinesManager.ManufactureTank(unitName, attackPoints, defensePoints);
                    break;
                case "ManufactureFighter":
                    var fighterAttackPoints = double.Parse(currentCommand.Arguments[1]);
                    var fighterDefensePoints = double.Parse(currentCommand.Arguments[2]);
                    message = this.machinesManager.ManufactureFighter(unitName, fighterAttackPoints, fighterDefensePoints);
                    break;
                case "MachineReport":
                    message = this.machinesManager.MachineReport(unitName);
                    break;
                case "AggressiveMode":
                    message = this.machinesManager.ToggleFighterAggressiveMode(unitName);
                    break;
                case "DefenseMode":
                    message = this.machinesManager.ToggleTankDefenseMode(unitName);
                    break;
                case "Engage":
                    var machineName = currentCommand.Arguments[1];
                    message = this.machinesManager.EngageMachine(unitName, machineName);
                    break;
                case "Attack":
                    var defendingMachine = currentCommand.Arguments[1];
                    message = this.machinesManager.AttackMachines(unitName, defendingMachine);
                    break;
                default:
                    break;
            }

            writer.Write(message);
        }
    }
}
