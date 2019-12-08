namespace MXGP.Core
{
    using MXGP.Core.Contracts;
    using MXGP.Models.Motorcycles;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Races;
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories;
    using MXGP.Repositories.Contracts;
    using System;
    using System.Linq;
    using System.Text;

    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IMotorcycle> motorcycleRepo;
        private IRepository<IRider> riderRepo;
        private IRepository<IRace> raceRepo;
        public ChampionshipController()
        {
            this.motorcycleRepo = new MotorcycleRepository();
            this.riderRepo = new RiderRepository();
            this.raceRepo = new RaceRepository();
        }

        public object IRacer { get; private set; }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riderRepo.GetByName(riderName);
            var motor = this.motorcycleRepo.GetByName(motorcycleModel);

            if (rider is null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            if (motor is null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            rider.AddMotorcycle(motor);

            return $"Rider {rider.Name} received motorcycle {motor.Model}.";

        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.raceRepo.GetByName(raceName);

            if (race is null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            var rider = this.riderRepo.GetByName(riderName);

            if (rider is null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            race.AddRider(rider);

            return $"Rider {rider.Name} added in {race.Name} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var checkIfMotorcycleExist = this.motorcycleRepo.GetByName(model) != null;

            if (checkIfMotorcycleExist)
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }

            Motorcycle newMotorCycle = null;

            if (type == "Power")
            {
                newMotorCycle = new PowerMotorcycle(model, horsePower);
            }
            else if (type == "Speed")
            {
                newMotorCycle = new SpeedMotorcycle(model, horsePower);
            }

            this.motorcycleRepo.Add(newMotorCycle);
            return $"{type}Motorcycle {model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var isTheRaceAlreadyCreated = this.raceRepo.GetByName(name) != null;

            if (isTheRaceAlreadyCreated)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            var race = new Race(name, laps);
            this.raceRepo.Add(race);

            return $"Race {name} is created.";
        }

        public string CreateRider(string riderName)
        {
            var rider = this.riderRepo.GetByName(riderName);

            if (rider != null)
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }

            rider = new Rider(riderName);
            this.riderRepo.Add(rider);

            return $"Rider {rider.Name} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepo.GetByName(raceName);

            if (race is null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            var raceParticipants = race.Riders.ToList();
            var minimumNumberOfParticipants = 3;

            if (raceParticipants.Count < minimumNumberOfParticipants)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var numberOfLaps = race.Laps;
            var allParticipantsInDescendingOrder = raceParticipants
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(numberOfLaps))
                .ToList();

            var firstRider = allParticipantsInDescendingOrder[0];
            firstRider.WinRace();
            var secondRider = allParticipantsInDescendingOrder[1];
            var thirdRider = allParticipantsInDescendingOrder[2];

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Rider {firstRider.Name} wins {race.Name} race.");
            stringBuilder.AppendLine($"Rider {secondRider.Name} is second in {race.Name} race.");
            stringBuilder.AppendLine($"Rider {thirdRider.Name} is third in {race.Name} race.");

            this.raceRepo.Remove(race);

            return stringBuilder.ToString().TrimEnd();
        }










        //public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        //{
        //    var rider = this.riderRepo.GetByName(riderName);
        //    var motor = this.motorcycleRepo.GetByName(motorcycleModel);

        //    if (rider is null)
        //    {
        //        return string.Format(ExceptionMessages.RiderNotFound, riderName);
        //    }
        //    if (motor is null)
        //    {
        //        return string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel);
        //    }

        //    rider.AddMotorcycle(motor);

        //    return string.Format(OutputMessages.MotorcycleAdded, rider.Name, motor.Model);

        //}

        //public string AddRiderToRace(string raceName, string riderName)
        //{
        //    var race = this.raceRepo.GetByName(raceName);

        //    if (race is null)
        //    {
        //        return string.Format(ExceptionMessages.RaceNotFound, raceName);
        //    }

        //    var rider = this.riderRepo.GetByName(riderName);

        //    if (rider is null)
        //    {
        //        return string.Format(ExceptionMessages.RiderNotFound, riderName);
        //    }

        //    race.AddRider(rider);

        //    return string.Format(OutputMessages.RiderAdded, rider.Name, race.Name);
        //}

        //public string CreateMotorcycle(string type, string model, int horsePower)
        //{
        //    var checkIfMotorcycleExist = this.motorcycleRepo.GetByName(model) != null;

        //    if (checkIfMotorcycleExist)
        //    {
        //        return string.Format(ExceptionMessages.MotorcycleExists, model);  //CHECK IF "CREATE" (not createD) works in Judge
        //    }

        //    Motorcycle newMotorCycle = null;

        //    if (type == "Power")
        //    {
        //        newMotorCycle = new PowerMotorcycle(model, horsePower);
        //    }
        //    else if (type == "Speed")
        //    {
        //        newMotorCycle = new SpeedMotorcycle(model, horsePower);
        //    }

        //    this.motorcycleRepo.Add(newMotorCycle);
        //    return string.Format(OutputMessages.MotorcycleCreated, type, model);
        //}

        //public string CreateRace(string name, int laps)
        //{
        //    var isTheRaceAlreadyCreated = this.raceRepo.GetByName(name) != null;

        //    if (isTheRaceAlreadyCreated)
        //    {
        //        return string.Format(ExceptionMessages.RaceExists, name);
        //    }

        //    var race = new Race(name, laps);
        //    this.raceRepo.Add(race);

        //    return string.Format(OutputMessages.RaceCreated, race.Name);
        //}

        //public string CreateRider(string riderName)
        //{
        //    var rider = this.riderRepo.GetByName(riderName);

        //    if (rider != null)
        //    {
        //        return string.Format(ExceptionMessages.RiderExists, riderName);
        //    }

        //    rider = new Rider(riderName);
        //    this.riderRepo.Add(rider);

        //    return string.Format(OutputMessages.RiderCreated, riderName);
        //}

        //public string StartRace(string raceName)
        //{
        //    var race = this.raceRepo.GetByName(raceName);

        //    if (race is null)
        //    {
        //        return string.Format(ExceptionMessages.RaceNotFound, raceName);
        //    }

        //    var raceParticipants = race.Riders.ToList();
        //    var minimumNumberOfParticipants = 3;

        //    if (raceParticipants.Count < 3)
        //    {
        //        return string.Format(ExceptionMessages.RaceInvalid, raceName, minimumNumberOfParticipants);
        //    }

        //    var numberOfLaps = race.Laps;
        //    var allParticipantsInDescendingOrder = raceParticipants
        //        .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(numberOfLaps))
        //        .ToList();

        //    var firstRider = allParticipantsInDescendingOrder[0];
        //    var secondRider = allParticipantsInDescendingOrder[1];
        //    var thirdRider = allParticipantsInDescendingOrder[2];

        //    var stringBuilder = new StringBuilder();
        //    stringBuilder.AppendLine($"Rider {firstRider.Name} wins {race.Name} race.");
        //    stringBuilder.AppendLine($"Rider {secondRider.Name} is second in {race.Name} race.");
        //    stringBuilder.AppendLine($"Rider {thirdRider.Name} is third in {race.Name} race.");

        //    this.raceRepo.Remove(race);

        //    return stringBuilder.ToString().Trim();
        //}
    }
}
