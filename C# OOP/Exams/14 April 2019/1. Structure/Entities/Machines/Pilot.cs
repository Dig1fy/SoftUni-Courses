using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    class Pilot : IPilot
    {

        private string name;
        private readonly List<IMachine> machines = new List<IMachine>();

        public Pilot(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine is null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {machines.Count} machines");

            foreach (var machine in machines)
            {
                sb.AppendLine($"{machine}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
