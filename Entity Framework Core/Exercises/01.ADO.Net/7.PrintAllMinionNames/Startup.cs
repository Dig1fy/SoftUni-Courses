using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _7.PrintAllMinionNames
{
    class Startup
    {
        static void Main()
        {
            var connection = new SqlConnection("Server = .; Database = MinionsDB; Integrated Security = true");
            connection.Open();

            var queryGetAllMinions = @"SELECT Name FROM Minions";
            using var getAllMinionsCommand = new SqlCommand(queryGetAllMinions, connection);
            using var reader = getAllMinionsCommand.ExecuteReader();

            var listOfMinions = new List<string>();

            while (reader.Read())
            {
                listOfMinions.Add(reader["Name"].ToString());
            }

            for (int i = 0; i < listOfMinions.Count / 2; i++)
            {
                Console.WriteLine(listOfMinions[i]);
                Console.WriteLine(listOfMinions[listOfMinions.Count - i - 1]);
            }

            if (listOfMinions.Count % 2 != 0)
            {
                Console.WriteLine(listOfMinions[listOfMinions.Count / 2]);
            }
        }
    }
}
