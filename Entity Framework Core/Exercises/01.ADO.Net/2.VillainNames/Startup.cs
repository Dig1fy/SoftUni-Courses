using Microsoft.Data.SqlClient;
using System;

namespace _2.VillainNames
{
    class Startup
    {
        static void Main()
        {
            //First we need to create and open an connection
            using SqlConnection connection = new SqlConnection(@"Server=. ; Database = MinionsDB; Integrated Security = true");
            connection.Open();

            //Here's the query we want to execute
            string query = @"SELECT v.Name + ' - ' + CONVERT(NVARCHAR,COUNT(mv.MinionId)) AS Output FROM Villains AS v 
                           JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
                           GROUP BY v.Id, v.Name
                           HAVING COUNT(mv.MinionId) > 2
                           ORDER BY COUNT(mv.MinionId)";

            //The output is a table so we need to use SqlReader (row by row)
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Output"]}");
            }
        }
    }
}
