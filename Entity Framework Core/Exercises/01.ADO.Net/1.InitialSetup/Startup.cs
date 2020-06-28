using Microsoft.Data.SqlClient;
using System;

namespace ADO.Net
{
    class Startup
    {
        static void Main()
        {
            //Connecting to masterDB
            using SqlConnection sqlConnection = new SqlConnection("Server=.; Database = master; Integrated Security = true");
            sqlConnection.Open();

            //Creating new Database - MinionsDb
            string query = "CREATE DATABASE MinionsDB";
            using SqlCommand command = new SqlCommand(query, sqlConnection);
            command.ExecuteNonQuery();

            //Connecting to the newly created DB - MinionsDB
            using SqlConnection secondConnection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=true");
            secondConnection.Open();

            //Creating Countries Table
            string queryCreateCountries = @"CREATE TABLE Countries (
                                       Id INT PRIMARY KEY IDENTITY,
                                       [Name] NVARCHAR(50))";
            using SqlCommand commandCreateCountries = new SqlCommand(queryCreateCountries, secondConnection);
            commandCreateCountries.ExecuteNonQuery();

            //Creating Towns Table
            string queryCreateTowns = @"CREATE TABLE Towns(
                                      Id INT PRIMARY KEY IDENTITY,
                                      [Name] NVARCHAR(50) NOT NULL,
                                      CountryCode INT REFERENCES Countries(Id))";
            using SqlCommand commandCreateTowns = new SqlCommand(queryCreateTowns, secondConnection);
            commandCreateTowns.ExecuteNonQuery();

            //Creating Minions Table
            string queryCreateMinions = @"CREATE TABLE Minions(
                                        Id INT PRIMARY KEY IDENTITY,
                                        [Name] NVARCHAR(50),
                                        Age INT,
                                        TownId INT REFERENCES Towns(Id))";
            using SqlCommand commandCreateMinions = new SqlCommand(queryCreateMinions, secondConnection);
            commandCreateMinions.ExecuteNonQuery();

            //Creating EvilnessFactors Table
            string queryCreateEvilnessFactors = @"CREATE TABLE EvilnessFactors(
                                                Id INT PRIMARY KEY IDENTITY,
                                                [Name] NVARCHAR(50))";
            using SqlCommand commandCreateEvilnessFactors = new SqlCommand(queryCreateEvilnessFactors, secondConnection);
            commandCreateEvilnessFactors.ExecuteNonQuery();

            //Creating Villains Table
            string queryVillainsTable = @"CREATE TABLE Villains (
                                        Id INT PRIMARY KEY IDENTITY,
                                        [Name] NVARCHAR(50),
                                        EvilnessFactorId INT REFERENCES EvilnessFactors(Id))";
            using SqlCommand commandCreateVillains = new SqlCommand(queryVillainsTable, secondConnection);
            commandCreateVillains.ExecuteNonQuery();

            //Creating MinionsVillains Table
            string queryMinionsVillains = @"CREATE TABLE MinionsVillains(
                                          MinionId INT REFERENCES Minions(Id),
                                          VillainId INT REFERENCES Villains(Id),
                                          CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))";
            using SqlCommand commandCreateMinionsVillains = new SqlCommand(queryMinionsVillains, secondConnection);
            commandCreateMinionsVillains.ExecuteNonQuery();

            // Inserting data into Countries
            var dataToCountries = @"INSERT INTO Countries ([Name]) VALUES 
                                  ('Bulgaria'),('Portugal'),
                                  ('Germany'),('England'),
                                  ('Macedonia')";
            using var insertIntoCountries = new SqlCommand(dataToCountries, secondConnection);
            insertIntoCountries.ExecuteNonQuery();

            // Inserting data into Towns
            var dataToTowns = @"INSERT INTO Towns ([Name], CountryCode) VALUES 
                              ('Sofia', 1),('Pazardzhik', 1),('Tyrnovo', 1),
                              ('Plovdiv', 1),('Albufeira', 2),('Almada', 2),
                              ('Amadora', 2),('Amarante', 2),('Munich', 3),
                              ('Frankfurt', 3),('London', 4)";
            using var insertIntoTowns = new SqlCommand(dataToTowns, secondConnection);
            insertIntoTowns.ExecuteNonQuery();

            // Inserting data into Minions
            var dataToMinions = @"INSERT INTO Minions (Name,Age, TownId) VALUES
                                ('Jully', 11, 3),('Kevin', 12, 1),('Bob ', 13, 6)
                                ,('Jully', 14, 3),('Cathleen', 15, 2),('Jimmy ', 16, 10)
                                ,('Becky', 17, 5),('Mars', 100, 1),('Steward', 55, 10)
                                ,('Zoe', 225, 5),('Jimmy', 1, 1)";
            using var insetIntoMinions = new SqlCommand(dataToMinions, secondConnection);
            insetIntoMinions.ExecuteNonQuery();

            // Inserting data into EvilnessFactors
            var dataToEvilnessFactors = @"INSERT INTO EvilnessFactors (Name) VALUES 
                                        ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')";
            using var insertIntoEvilnessFactors = new SqlCommand(dataToEvilnessFactors, secondConnection);
            insertIntoEvilnessFactors.ExecuteNonQuery();

            //Inserting data into Villains
            var dataToVillains = @"INSERT INTO Villains (Name, EvilnessFactorId) VALUES 
                                 ('Gru',2),('Victor',1),('Gosho',3),
                                 ('Pesho',4),('Hasan',5),('Ivan',1),('Onzi',2)";
            using var insertIntoVillains = new SqlCommand(dataToVillains, secondConnection);
            insertIntoVillains.ExecuteNonQuery();

            //Inserting data into MinionsVillains
            var dataToMinionsVillains = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES 
                                        (1,1),(2,1),(3,5),(2,6),(7,3),(7,1),(8,4),(9,7),
                                        (1,3),(5,7),(5,3),(4,3),(1,2),(11,5),(2,7),(4,2)";
            using var insertIntoMinionsVillains = new SqlCommand(dataToMinionsVillains, secondConnection);
            insertIntoMinionsVillains.ExecuteNonQuery();
        }
    }
}