namespace BorderControl
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        public void Run()
        {
            var command = string.Empty;
            var allInhabitants = new List<IIdentifiable>();

            while ((command = Reader.ReadLine()) != "End")
            {
                var commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (commandArgs.Length)
                {
                    case 3:
                        var citizenId = commandArgs[2];
                        var citizen = new Citizen(citizenId);
                        allInhabitants.Add(citizen);
                        break;
                    case 2:
                        var robotId = commandArgs[1];
                        var robot = new Robot(robotId);
                        allInhabitants.Add(robot);
                        break;
                    default:
                        break;
                }
            }

            var idToCheck = Reader.ReadLine();
            var inhabitatntsWithFakeIds = Validator.Validate(allInhabitants, idToCheck);
            Writer.WriteLine(string.Join(Environment.NewLine, inhabitatntsWithFakeIds));
        }      
    }
}
