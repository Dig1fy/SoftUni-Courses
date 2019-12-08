namespace MXGP.Core
{
    using MXGP.Core.Contracts;
    using MXGP.IO.Contracts;
    using System;

    public class Engine : IEngine
    {
        private IWriter ConsoleWriter;
        private IReader ConsoleReader;
        private IChampionshipController controller;

        public Engine(IWriter writer, IReader reader, IChampionshipController controller)
        {
            this.ConsoleReader = reader;
            this.ConsoleWriter = writer;
            this.controller = controller;
        }
        public void Run()
        {
            var input = this.ConsoleReader.ReadLine();
            var endCommand = "End";
            var message = string.Empty;

            while (input != endCommand)
            {
                var inputArgs = input.Split();

                try
                {
                    var command = inputArgs[0];
                    var currentName = inputArgs[1];

                    switch (command)
                    {
                        case "CreateRider":
                            message = this.controller.CreateRider(currentName);
                            break;
                        case "CreateMotorcycle":
                            var type = inputArgs[1];
                            var model = inputArgs[2];
                            var horsePower = int.Parse(inputArgs[3]);
                            message = this.controller.CreateMotorcycle(type, model, horsePower);
                            break;
                        case "AddMotorcycleToRider":
                            var motorcycleModel = inputArgs[2];
                            message = this.controller.AddMotorcycleToRider(currentName, motorcycleModel);
                            break;
                        case "AddRiderToRace":
                            var currentRiderName = inputArgs[2];
                            message = this.controller.AddRiderToRace(currentName, currentRiderName);
                            break;
                        case "CreateRace":
                            var laps = int.Parse(inputArgs[2]);
                            message = this.controller.CreateRace(currentName, laps);
                            break;
                        case "StartRace":
                            message = this.controller.StartRace(currentName);
                            break;

                        default:
                            break;
                    }

                }
                catch (Exception ex)
                {
                    ConsoleWriter.WriteLine(ex.Message);
                }
                finally
                {
                    this.ConsoleWriter.WriteLine(message);
                    input = this.ConsoleReader.ReadLine();
                }
            }
        }
    }
}
