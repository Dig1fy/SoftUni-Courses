using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace _8.IncreaseMinionAge
{
    class Startup
    {
        static void Main()
        {
            //Create and open connection to the DB
            var connection = new SqlConnection("Server = . ; Database = MinionsDB ; Integrated Security = true");
            connection.Open();

            //Getting the input Ids from the console
            var inputIds = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                       
            var queryAdjustMinionsData = @"UPDATE Minions
                                          SET Age += 1, Name = UPPER(SUBSTRING(Name, 1, 1)) + SUBSTRING(Name, 2, LEN(Name))
                                          WHERE Id = @Id";

            //Execute the command and increase age + first letter of the minions name for all minions with corresponding ids.
            foreach (var id in inputIds)
            {
                using var commandAdjustMinionsData = new SqlCommand(queryAdjustMinionsData, connection);
                commandAdjustMinionsData.Parameters.AddWithValue("@Id", id);
                commandAdjustMinionsData.ExecuteNonQuery();
            }

            //Select all minions and print them.
            var queryGetMinions = "SELECT Name, Age FROM Minions";
            using var commandGetMinions = new SqlCommand(queryGetMinions, connection);
            using var reader = commandGetMinions.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
            }
        }
    }
}