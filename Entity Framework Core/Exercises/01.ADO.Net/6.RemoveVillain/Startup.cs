using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _6.RemoveVillain
{
    class Startup
    {
        static void Main()
        {

            var connection = new SqlConnection("Server = .; Database = MinionsDB; Integrated Security = true");
            connection.Open();

            var villainID = int.Parse(Console.ReadLine());

            var result = RemoveVillainById(connection, villainID);
            Console.WriteLine(result);
        }

        private static object RemoveVillainById(SqlConnection connection, int villainID)
        {
            var sb = new StringBuilder();
            //We start a transaction so all commands happen at once (or none)
            using SqlTransaction sqlTransaction = connection.BeginTransaction();

            var queryGetVillainName = @"SELECT Name FROM Villains WHERE Id = @villainId";
            using var commandGetVillainName = new SqlCommand(queryGetVillainName, connection);
            commandGetVillainName.Parameters.AddWithValue("@villainId", villainID);

            //We need to chain the transaction to the command
            commandGetVillainName.Transaction = sqlTransaction;

            var villainName = commandGetVillainName.ExecuteScalar()?.ToString();

            if (villainName is null)
            {
                sb.AppendLine("No such villain was found.");
            }
            else
            {
                try
                {
                    var releaseMinionsQuery = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";
                    using var releaseVillainCmd = new SqlCommand(releaseMinionsQuery, connection);
                    releaseVillainCmd.Parameters.AddWithValue("@villainId", villainID);

                    //We chain the transaction to each action
                    releaseVillainCmd.Transaction = sqlTransaction;
                    var rowsAffected = releaseVillainCmd.ExecuteNonQuery();

                    var deleteVillainsQuery = @"DELETE FROM Villains WHERE Id = @villainId";
                    using var deleteVillainCmd = new SqlCommand(deleteVillainsQuery, connection);
                    deleteVillainCmd.Parameters.AddWithValue("@villainId", villainID);

                    deleteVillainCmd.Transaction = sqlTransaction;
                    deleteVillainCmd.ExecuteNonQuery();

                    //After all the actions we chained to the transaction, we need to Commit the changes. 
                    sqlTransaction.Commit();

                    //If all actions have succeeded after the transaction, we can proceed with the text output
                    sb.AppendLine($"{villainName} was deleted.");
                    sb.AppendLine($"{rowsAffected} minions were relased.");
                }
                catch (Exception ex)
                {
                    //First we append the error message
                    sb.AppendLine(ex.Message);

                    //Then we discard all changes with rollback. The rollback itself can throw an exception so we put it in try-catch block
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception rollbackEx)
                    {
                        sb.AppendLine(rollbackEx.Message);
                    }                   
                   
                }
            }

            return sb.ToString().Trim();

        }
    }
}
