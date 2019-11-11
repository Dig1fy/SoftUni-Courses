using System.Collections.Generic;
using System.Linq;

public class Engine
{
    public void Run()
    {
        List<IBirthable> allInhabitants = new List<IBirthable>();

        string command;

        while ((command = Reader.ReadLine()) != "End")
        {
            var tokens = command.Split();

            switch (tokens[0])
            {
                case "Citizen":
                    allInhabitants.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
                    break;
                case "Pet":
                    allInhabitants.Add(new Pet(tokens[1], tokens[2]));
                    break;
            }
        }

        int year = int.Parse(Reader.ReadLine());

        allInhabitants.Where(c => c.Birthdate.Year == year)
            .Select(c => c.Birthdate)
            .ToList()
            .ForEach(dt => Writer.WriteLine($"{dt:dd/mm/yyyy}"));
    }
}

