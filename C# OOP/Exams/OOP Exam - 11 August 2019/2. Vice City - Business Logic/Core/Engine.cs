namespace ViceCity.Core
{
    using ViceCity.Core.Contracts;
    using System;
    using ViceCity.IO.Contracts;
    using ViceCity.IO;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;

        public Engine(IController controller)
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = controller;
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                var message = string.Empty;

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddPlayer")
                    {
                        message = controller.AddPlayer(input[1]);
                    }
                    else if (input[0] == "AddGun")
                    {
                        message = controller.AddGun(input[1], input[2]);
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        message = controller.AddGunToPlayer(input[1]);
                    }
                    else if (input[0] == "Fight")
                    {
                        message = controller.Fight();
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
