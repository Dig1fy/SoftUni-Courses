using MortalEngines.Commands;
using MortalEngines.Core;
using MortalEngines.Core.Contracts;
using MortalEngines.Factories;
using MortalEngines.Factories.Contracts;
using MortalEngines.IO;
using MortalEngines.IO.Contracts;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            IFighterFactory fighterFactory = new FighterFactory();
            ITankFactory tankFactory = new TankFactory();
            IPilotFactory pilotFactory = new PilotFactory();

            IReader reader = new Reader();
            IWriter writer = new Writer();
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IMachinesManager machinesManager = new MachinesManager
                (fighterFactory
                ,tankFactory
                ,pilotFactory);

            var engine = new Engine(reader, writer,commandInterpreter, machinesManager);
                engine.Run();


        }
    }
}