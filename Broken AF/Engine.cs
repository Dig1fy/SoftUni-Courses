using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {

            while (true)
            {
                var input = Console.ReadLine();

                var output = this.commandInterpreter.Read(input);

                Console.WriteLine(output);
            }
        }
    }
}
