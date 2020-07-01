using Microsoft.Data.SqlClient;
using System;

namespace _9.IncreaseAgeStoredProcedure
{
    class Startup
    {
        static void Main()
        {
            //Create and open connection to the DB
            var connection = new SqlConnection("Server = . ; Database = MinionsDB ; Integrated Security = true");
            connection.Open();

            //The minionId comes from the console
            var inputId = int.Parse(Console.ReadLine());

            //Use the stored procedure via command
            using var commandStoredProcedure = new SqlCommand("usp_GetOlder", connection);
            commandStoredProcedure.CommandType = System.Data.CommandType.StoredProcedure;
            commandStoredProcedure.Parameters.AddWithValue("@MinionId", inputId);
            commandStoredProcedure.ExecuteNonQuery();

            //Get the Minion with the given id and print his name and age
            var queryGetTheAdjustedMinion = @"SELECT Name, Age
                                            FROM Minions
                                            WHERE Id = @Id";
            using var commandGetTheAdjustedMinion = new SqlCommand(queryGetTheAdjustedMinion, connection);
            commandGetTheAdjustedMinion.Parameters.AddWithValue("@Id", inputId);
            using var reader = commandGetTheAdjustedMinion.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} - {reader["Age"]} years old");
            }

            //------This code is for the stored procedure in MSSQL--------
            //CREATE PROC usp_GetOlder @MinionId INT
            //AS
            //BEGIN
            //    UPDATE Minions
            //    SET Age += 1
            //    WHERE Id = @MinionId
            //END
        }
    }
}