using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace _5.ChangeTownNameCasing
{
    class Startup
    {
        static void Main()
        {
            //Create/open connection to the db
            var countryName = Console.ReadLine();
            using var connection = new SqlConnection("Server = . ; Database = MinionsDB; Integrated Security = true");
            connection.Open();

            //query for update of all towns in a certain country
            var queryUpdateCities = @"UPDATE Towns
                                    SET Name = UPPER(Name)
                                    WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            using var command = new SqlCommand(queryUpdateCities, connection);
            command.Parameters.AddWithValue("@countryName", countryName);
            var affectedRows = command.ExecuteNonQuery();

            if (affectedRows == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                Console.WriteLine($"{affectedRows} town names were affected.");

                var queryTownNames = @"SELECT UPPER(t.Name) AS Name
                                        FROM Towns as t
                                        JOIN Countries AS c ON c.Id = t.CountryCode
                                        WHERE c.Name = 'Bulgaria'";

                //Update all towns with upper casing
                using var commandChangeTownsToUpper = new SqlCommand(queryTownNames, connection);
                commandChangeTownsToUpper.Parameters.AddWithValue("@countryName", countryName);
                using var reader = commandChangeTownsToUpper.ExecuteReader();
                
                //We put all affected towns in list so we can print them easier into the desired format
                var listOfTowns = new List<string>();

                while (reader.Read())
                {
                    var town = reader["Name"].ToString();
                    listOfTowns.Add(town);
                }

                Console.WriteLine($"[{string.Join(", ", listOfTowns)}]");
            }
        }
    }
}
