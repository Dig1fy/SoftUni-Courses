-- *********************** Problem 1 - DDL ***********************
--CREATE DATABASE Airport

CREATE TABLE Planes (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin NVARCHAR(50) NOT NULL,
	Destination NVARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] NVARCHAR(30) NOT NULL,
	PassportId NCHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes (
	Id INT PRIMARY KEY IDENTITY,
	[Type] NVARCHAR(30) NOT NULL
)

CREATE TABLE Luggages (
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes (Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers (Id) NOT NULL
)

CREATE TABLE Tickets (
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL (10,2) NOT NULL
)


-- *********************** Problem 2 - Insert ***********************
INSERT INTO Planes ([Name], Seats, [Range]) VALUES
	('Airbus 336', 112, 5132),
	('Airbus 330', 432, 5325),
	('Boeing 369', 231, 2355),
	('Stelt 297', 254, 2143),
	('Boeing 338', 165, 5111),
	('Airbus 558', 387, 1342),
	('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes ([Type]) VALUES
	('Crossbody Bag'),
	('School Backpack'),
	('Shoulder Bag')


-- *********************** Problem 3 - Update ***********************
UPDATE Tickets 
SET Price *= 1.13
WHERE FlightId = (SELECT TOP(1) Id FROM Flights WHERE Destination = 'Carlsbad')


-- *********************** Problem 4 - Delete ***********************
DELETE FROM Tickets
WHERE FlightId = (SELECT TOP(1) Id FROM Flights WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'


-- *********************** Problem 5 - Trips ***********************
SELECT Origin, Destination FROM Flights
ORDER BY Origin, Destination


-- *********************** Problem 6 - The "Tr" Planes ***********************
SELECT * FROM Planes
WHERE Name LIKE '%tr%'
ORDER BY Id, Name, Seats, Range


-- *********************** Problem 7 - Flight Profits ***********************
SELECT FlightId, SUM(Price) AS Price FROM Tickets
GROUP BY FlightId
ORDER BY Price DESC, FlightId


-- *********************** Problem 8 - Passanger and Prices ***********************
SELECT TOP(10) p.FirstName, p.LastName, t.Price FROM Passengers AS p
JOIN Tickets AS t ON t.PassengerId = p.Id
ORDER BY t.Price DESC, p.FirstName, p.LastName


-- *********************** Problem 9 - Most Used Luggage's ***********************
SELECT [Type], COUNT(*) AS MostUsedLuggage FROM Luggages AS l
JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
GROUP BY Type
ORDER BY MostUsedLuggage DESC, Type


-- *********************** Problem 10 - Passanger Trips ***********************
SELECT p.FirstName + ' ' + p.LastName AS [Full Name], f.Origin, f.Destination FROM Passengers AS p 
JOIN Tickets AS t ON t.PassengerId = p.Id
JOIN Flights AS f ON f.Id = t.FlightId
ORDER BY [Full Name], Origin, Destination


-- *********************** Problem 11 - Non Adventures People ***********************
SELECT p.FirstName, p.LastName, p.Age FROM Passengers AS p 
LEFT JOIN Tickets AS t ON p.Id = t.PassengerId
WHERE t.FlightId IS NULL
ORDER BY p.Age DESC, p.FirstName, p.LastName


-- *********************** Problem 12 - Lost Luggage's ***********************
SELECT p.PassportId AS [Passport Id], p.Address FROM Passengers AS p
LEFT JOIN Luggages AS l ON p.Id = l.PassengerId
WHERE l.Id IS NULL
ORDER BY p.PassportId, p.Address


-- *********************** Problem 13 - Count of Trips ***********************
SELECT p.FirstName, p.LastName, COUNT(t.FlightId) AS [Total Trips] FROM Passengers AS p 
LEFT JOIN Tickets AS t ON t.PassengerId = p.Id
GROUP BY p.FirstName, p.LastName
ORDER BY [Total Trips] DESC, p.FirstName, p.LastName

-- *********************** Problem 14 - Full Info ***********************
SELECT 
	p.FirstName + ' ' + p.LastName AS [Full Name],
	pl.Name AS [Plane Name],
	f.Origin + ' - ' + f.Destination AS Trip,
	lt.Type AS [Luggage Type]
FROM Passengers AS p 
	JOIN Tickets AS t ON t.PassengerId = p.Id
	JOIN Flights AS f ON f.Id = t.FlightId
	JOIN Planes AS pl ON pl.Id = f.PlaneId
	JOIN Luggages AS l ON l.Id = t.LuggageId
	JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
ORDER BY [Full Name], Name, Origin, Destination, Type


-- *********************** Problem 15 - Most Expensive Trips ***********************
SELECT temp.FirstName, temp.LastName, temp.Destination, temp.Price
	FROM
		(SELECT 
			p.FirstName, 
			p.LastName, 
			f.Destination, 
			t.Price, 
			ROW_NUMBER() OVER(PARTITION BY	p.FirstName, p.LastName ORDER BY t.Price DESC) AS PriceRank
		
		FROM Passengers AS p
		JOIN Tickets AS t ON t.PassengerId = p.Id
		JOIN Flights AS f ON f.Id = t.FlightId
		) AS temp

WHERE temp.PriceRank = 1
ORDER BY Price DESC, FirstName, LastName, Destination


-- *********************** Problem 16 - Destinations Info ***********************
SELECT f.Destination, COUNT(t.FlightId) AS FilesCount 
	FROM Flights AS f
	LEFT JOIN Tickets AS t 
		ON t.FlightId = f.Id
GROUP BY f.Destination
ORDER BY COUNT(t.FlightId) DESC, f.Destination


-- *********************** Problem 17 - PSP ***********************
SELECT p.Name, p.Seats, COUNT(t.Id) AS [Passengers Count] 
	FROM Planes AS p
	LEFT JOIN Flights AS f 
		ON f.PlaneId = p.Id
	LEFT JOIN Tickets AS t 
		ON t.FlightId = f.Id
GROUP BY p.Name, p.Seats
ORDER BY COUNT(t.Id) DESC, p.Name, p.Seats


-- *********************** Problem 18 - Vacation ***********************
CREATE FUNCTION udf_CalculateTickets(@origin NVARCHAR(30), @destination NVARCHAR(30), @peopleCount INT) 
RETURNS NVARCHAR(40) 
AS
BEGIN

IF (@peopleCount <= 0) 
	BEGIN
		RETURN 'Invalid people count!'
	END

DECLARE @tripId INT = (SELECT f.Id FROM Flights AS f
					   JOIN Tickets AS t ON t.FlightId = f.Id
					   WHERE @origin = f.Origin AND @destination = f.Destination)
IF (@tripId IS NULL)
	BEGIN
		RETURN 'Invalid flight!'
	END
ELSE
	BEGIN
		DECLARE @TicketPrice DECIMAL(10,2);
		DECLARE @TotalPrice DECIMAL(10,2);
		
		SELECT @TicketPrice = Price FROM Flights AS f
		JOIN Tickets AS t ON t.FlightId = f.Id
		WHERE f.Origin = @origin AND f.Destination = @destination
		
		SET @TotalPrice = @TicketPrice * @peopleCount
		RETURN ('Total price ' + CAST(@TotalPrice AS NVARCHAR(50)))
	END
	RETURN ''
END


-- *********************** Problem 19 - Wrong Data ***********************
CREATE PROC usp_CancelFlights AS
UPDATE Flights
SET ArrivalTime = NULL, DepartureTime = NULL 
WHERE ArrivalTime > DepartureTime


-- *********************** Problem 20 - Deleted Planes ***********************
CREATE TABLE DeletedPlanes (
	Id INT,
	[Name] NVARCHAR(50),
	Seats INT,
	[Range] INT
)

CREATE TRIGGER tr_DeletedPlanes ON Planes
AFTER DELETE AS
	INSERT INTO DeletedPlanes (Id, [Name], Seats, [Range])
	(SELECT Id, [Name], Seats, [Range] FROM deleted)