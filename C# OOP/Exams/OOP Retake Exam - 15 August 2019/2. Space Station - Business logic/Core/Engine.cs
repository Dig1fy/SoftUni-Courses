using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;
        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var message = string.Empty;

                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        message = this.controller.AddAstronaut(input[1], input[2]);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        message = this.controller.AddPlanet(input[1], input.Skip(2).ToArray());
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        message = this.controller.RetireAstronaut(input[1]);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        message = this.controller.ExplorePlanet(input[1]);
                    }
                    else if(input[0] == "Report")
                    {
                        message = this.controller.Report();
                    }

                    writer.WriteLine(message);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
