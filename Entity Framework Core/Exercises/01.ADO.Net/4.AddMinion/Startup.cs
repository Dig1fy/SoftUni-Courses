using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace _4.AddMinion
{
    public class Startup
    {
        static void Main()
        {
            //Read the input
            var minionInput = Console.ReadLine().Split(' ').ToArray();
            var minionName = minionInput[1];
            var minionAge = int.Parse(minionInput[2]);
            var minionTownName = minionInput[3];
            var villainName = Console.ReadLine().Split(' ')[1];

            //Create/open a new connection to the db
            var connection = new SqlConnection("Server = .; Database = MinionsDB; Integrated Security = true");
            connection.Open();

            //All queries we need
            var queryTownSearch = "SELECT Id FROM Towns WHERE @Name = Name";
            var queryMinionSearch = "SELECT Id FROM Minions WHERE @Name = Name";
            var queryVillainSearch = "SELECT Id FROM Villains WHERE @Name = Name";

            //Search for a town
            using var command = new SqlCommand(queryTownSearch, connection);
            command.Parameters.AddWithValue("@Name", minionTownName);
            var currentTown = command.ExecuteScalar();

            if (currentTown is null)
            {
                var addTownQuery = @"INSERT INTO Towns (Name) VALUES (@townName)";
                using var addTownCommand = new SqlCommand(addTownQuery, connection);
                addTownCommand.Parameters.AddWithValue("@townName", minionTownName);
                addTownCommand.ExecuteNonQuery();
                Console.WriteLine($"Town {minionTownName} was added to the database.");
            }

            //Check for villain
            using var villainCommand = new SqlCommand(queryVillainSearch, connection);
            villainCommand.Parameters.AddWithValue("@Name", villainName);
            var currentVillain = villainCommand.ExecuteScalar();

            if (currentVillain is null)
            {
                var queryAddVillain = @"INSERT INTO Villains (Name, EvilnessFactorId) VALUES (@Name, 4)";
                using var addVillainCommaind = new SqlCommand(queryAddVillain, connection);
                addVillainCommaind.Parameters.AddWithValue("@Name", villainName);
                addVillainCommaind.ExecuteNonQuery();
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            //Check for minion
            using var searchForMinionCommand = new SqlCommand(queryMinionSearch, connection);
            searchForMinionCommand.Parameters.AddWithValue("@Name", minionName);
            var currentMinion = searchForMinionCommand.ExecuteScalar();

            if (currentMinion is null) 
            {
                using var commandTownId = new SqlCommand(queryTownSearch, connection);
                commandTownId.Parameters.AddWithValue("@TownName", minionTownName);
                var townId = (int)commandTownId.ExecuteScalar();

                var queryAddMinion = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@Name, @Age, @TownId)";
                using var commandAddMinion = new SqlCommand(queryAddMinion, connection);
                commandAddMinion.Parameters.AddWithValue("@Name", minionName);
                commandAddMinion.Parameters.AddWithValue("@Age", minionAge);
                commandAddMinion.Parameters.AddWithValue("@TownId", townId);
                commandAddMinion.ExecuteNonQuery();
            }

            //Add Minion to villain
            else
            {
                //Find Villain Id
                using var commandVillainId = new SqlCommand(queryVillainSearch, connection);
                commandVillainId.Parameters.AddWithValue("@Name", villainName);
                var villainId = (int)commandVillainId.ExecuteScalar();

                // Find Minion Id
                using var commandMinionId = new SqlCommand(queryMinionSearch, connection);
                commandMinionId.Parameters.AddWithValue("@Name", minionName);
                var minionId = (int)commandMinionId.ExecuteScalar();

                var addMinionToVillainQuery = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
                using var commandAddMinionToVillain = new SqlCommand(addMinionToVillainQuery, connection);
                commandAddMinionToVillain.Parameters.AddWithValue("@villainId", villainId);
                commandAddMinionToVillain.Parameters.AddWithValue("@minionId", minionId);
                commandAddMinionToVillain.ExecuteNonQuery();
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }
    }
}
