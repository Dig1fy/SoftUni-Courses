namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Factories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private IFighterFactory fighterFactory;
        private ITankFactory tankFactory;
        private IPilotFactory PilotFactory;
        private IList<IPilot> pilots;
        private IList<IMachine> machines;

        public MachinesManager(
            IFighterFactory fighterFactory
            , ITankFactory tankFactory
            , IPilotFactory pilotFactory)
        {
            this.fighterFactory = fighterFactory;
            this.tankFactory = tankFactory;
            PilotFactory = pilotFactory;

            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (pilots.Any(x => x.Name.Equals(name)))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }

            var currentPilot = this.PilotFactory.CreatePilot(name);
            this.pilots.Add(currentPilot);
            return string.Format(OutputMessages.PilotHired, name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(x => x.Name.Equals(name)))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            var currentTank = tankFactory.CreateTank(name, attackPoints, defensePoints);
            machines.Add(currentTank);
            return string.Format(OutputMessages.TankManufactured
                , name
                , currentTank.AttackPoints
                , currentTank.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(x => x.Name.Equals(name)))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            var currentFighter = fighterFactory.CreateFighter(name, attackPoints, defensePoints);
            machines.Add(currentFighter);
            return string.Format(OutputMessages.FighterManufactured
                , name
                , currentFighter.AttackPoints
                , currentFighter.DefensePoints
                , currentFighter.AggressiveMode ? "ON" : "OFF");
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var currentPilot = pilots.FirstOrDefault(x => x.Name.Equals(selectedPilotName));

            if (currentPilot is null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            var currentMachine = machines.FirstOrDefault(x => x.Name.Equals(selectedMachineName));

            if (currentMachine is null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (currentMachine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            currentMachine.Pilot = currentPilot;
            return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = machines.FirstOrDefault(x => x.Name.Equals(attackingMachineName));
            var defendingMachine = machines.FirstOrDefault(x => x.Name.Equals(defendingMachineName));

            if (attackingMachine is null || defendingMachine is null)
            {
                var machine = attackingMachine == null ? attackingMachineName : defendingMachineName;
                return string.Format(OutputMessages.MachineNotFound, machine);
            }

            if (attackingMachine.HealthPoints == 0 || defendingMachine.HealthPoints == 0)
            {
                var machineName = attackingMachine == null ? attackingMachineName : defendingMachineName;
                return string.Format(OutputMessages.DeadMachineCannotAttack, machineName);
            }

            attackingMachine.Attack(defendingMachine);

            return string.Format(OutputMessages.AttackSuccessful
                , defendingMachineName
                , attackingMachineName
                , defendingMachine.HealthPoints);

        }

        public string PilotReport(string pilotReporting)
        {
            var reportingPilot = pilots.FirstOrDefault(x => x.Name.Equals(pilotReporting));

            return reportingPilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var currentMachine = machines.FirstOrDefault(x => x.Name.Equals(machineName));

            return currentMachine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var fighter = (IFighter)machines.FirstOrDefault(x => x.Name.Equals(fighterName) && x.GetType().Name == "Fighter");

            if (fighter is null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            fighter.ToggleAggressiveMode();
            return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            ITank tank = (ITank)machines.FirstOrDefault(x => x.Name.Equals(tankName) && x.GetType().Name == "Tank");

            if (tank is null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            tank.ToggleDefenseMode();
            return string.Format(OutputMessages.TankOperationSuccessful, tankName);
        }
    }
}