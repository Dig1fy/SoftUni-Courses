namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Commands.Contracts;
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.IO.Contracts;
    using System;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IManagerController managerController;
        private ICommandInterpreter commandInterpreter;

        public Engine(IWriter writer, IReader reader, IManagerController managerController, ICommandInterpreter commandInterpreter)
        {
            this.writer = writer;
            this.reader = reader;
            this.managerController = managerController;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            var endCommand = "Exit";
            var input = string.Empty;

            while ((input = this.reader.ReadLine()) != endCommand)
            {
                try
                {
                    var args = input.Split();
                    var message = this.commandInterpreter.Interpret(args, managerController);
                    this.writer.WriteLine(message);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
