namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            var allTeams = new List<Team>();
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                var action = tokens[0];
                var teamName = tokens[1];
                
                try
                {
                    switch (action)
                    {
                        case "Team":
                            allTeams.Add(new Team(teamName));
                            break;

                        case "Add":
                            if (!allTeams.Any(t => t.Name == tokens[1]))
                            {
                                throw new ArgumentException($"Team {tokens[1]} does not exist.");
                            }
                            else
                            {
                                var currentTeam = allTeams.First(t => t.Name == tokens[1]);
                                currentTeam.AddPlayer(CreatePlayer(tokens));
                            }
                            break;
                        case "Remove":
                            var containingTeam = allTeams.First(x => x.Name.Equals(teamName));
                            containingTeam.RemovePlayer(tokens[2], teamName);
                            break;
                        case "Rating":
                            if (!CheckIfTeamExists(teamName, allTeams))
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                            var teamToRate = allTeams.First(x => x.Name.Equals(teamName));
                            Console.WriteLine(teamToRate);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }   
        }

        private Player CreatePlayer(string[] tokens)
        {
            
            var name = tokens[2];
            var endurance = int.Parse(tokens[3]);
            var sprint = int.Parse(tokens[4]);
            var dribble = int.Parse(tokens[5]);
            var passing = int.Parse(tokens[6]);
            var shooting = int.Parse(tokens[7]);
            var player = new Player(name, endurance, sprint, dribble, passing, shooting);
            return player;
        }

        private bool CheckIfTeamExists(string currentTeam, List<Team> allTeams)
        {
            foreach (var team in allTeams)
            {
                if (currentTeam == team.Name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
