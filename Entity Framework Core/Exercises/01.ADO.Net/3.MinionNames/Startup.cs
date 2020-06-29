using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _3.MinionNames
{
    class Startup
    {
        static void Main()
        {
            //Create and open connection to the DB
            using SqlConnection sqlConnection = new SqlConnection("Server=.; Database = MinionsDB; Integrated Security = true");
            sqlConnection.Open();
            int villainId = int.Parse(Console.ReadLine());

            //We create a query and pass to it the ID to check for the villain
            string queryVillainId = @"SELECT Name FROM Villains WHERE Id = @Id";
            using SqlCommand command = new SqlCommand(queryVillainId, sqlConnection);
            command.Parameters.AddWithValue("@Id", villainId);

            //It always returns an object so we need .ToString(), keeping in mind it could return null if there is no such villain
            var villainName = command.ExecuteScalar()?.ToString();

            if (string.IsNullOrEmpty(villainName))
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            }
            else
            {
                //Add minions to the villain
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Villain: {villainName}");

                string queryMinions = @"SELECT 
                                       m.Name, 
                                       m.Age
                                     FROM MinionsVillains AS mv
                                     JOIN Minions As m ON mv.MinionId = m.Id
                                     WHERE mv.VillainId = 2
                                     ORDER BY m.Name";

                using SqlCommand commandMinions = new SqlCommand(queryMinions, sqlConnection);
                commandMinions.Parameters.AddWithValue("@Id", villainId);
                using SqlDataReader reader = commandMinions.ExecuteReader();

                if (!reader.HasRows)
                {
                    sb.AppendLine("(no minions)");
                }
                else
                {
                    int rowNum = 1;

                    while (reader.Read())
                    {
                        sb.AppendLine($"rowNum. {reader["Name"]} {reader["Age"]}");
                        rowNum++;
                    }
                }

                //Print the final result
                Console.WriteLine(sb.ToString().Trim());
            }
        }
    }
}
