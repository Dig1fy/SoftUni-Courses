--**************************PROBLEM 1 - DDL*******************************
--CREATE DATABASE TripService

CREATE TABLE Cities(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode NVARCHAR(2) NOT NULL
)

CREATE TABLE Hotels(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15,2)
)

CREATE TABLE Rooms(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(15,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT REFERENCES Rooms(Id) NOT NULL,
	BookDate DATETIME NOT NULL,
	ArrivalDate DATETIME NOT NULL,
	ReturnDate DATETIME NOT NULL,
	CancelDate DATETIME

CONSTRAINT bookDate_ArrivalDate CHECK (BookDate < ArrivalDate),
CONSTRAINT arrivalDate_ReturnDate CHECK (ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20), 
	LastName NVARCHAR(50) NOT NULL,
	CityId INT REFERENCES Cities(Id) NOT NULL,
	BirthDate DATETIME NOT NULL,
	Email NVARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE AccountsTrips(
	AccountId INT REFERENCES Accounts(Id) NOT NULL,
	TripId INT REFERENCES Trips(Id) NOT NULL,
	Luggage INT CHECK(Luggage >= 0) NOT NULL,
	CONSTRAINT PK_AccountTrips PRIMARY KEY (AccountId, TripId)
)


--**************************PROBLEM 2 - Insert *******************************
INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email) VALUES 
	('John', 'Smith', 'Smith', 34 , '1975-07-21', 'j_smith@gmail.com'),
	('Gosho', NULL, 'Petrov', 11 , '1978-05-16', 'g_petrov@gmail.com'),
	('Ivan', 'Petrovich', 'Pavlov', 59 , '1849-09-26', 'i_pavlov@softuni.bg'),
	('Friedrich', 'Wilhelm', 'Nietzsche', 2 , '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate) VALUES
	( 101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
	( 102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
	( 103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
	( 104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
	( 109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)


--**************************PROBLEM 3 - Update *******************************
UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN (5,7,9)


--**************************PROBLEM 4 - Delete *******************************
DELETE FROM AccountsTrips
WHERE AccountId = 47

DELETE FROM Accounts
WHERE Id = 47


--**************************PROBLEM 5 - EEE-Mails *******************************
SELECT FirstName, LastName, FORMAT(a.BirthDate, 'MM-dd-yyyy') AS BirthDate, c.Name AS Hometown, Email FROM Accounts AS a
JOIN Cities AS c ON c.Id = a.CityId
WHERE a.Email LIKE 'e%'
ORDER BY c.Name


--**************************PROBLEM 6 - City Statistics *******************************
SELECT c.Name, COUNT(h.Id) AS Hotels FROM Cities  AS c
JOIN Hotels AS h ON c.Id = h.CityId
GROUP BY c.Name
ORDER BY COUNT(h.Id) DESC, c.Name


--**************************PROBLEM 7 - Longest and Shortest Trips *******************************
SELECT 
	a.Id AS AccountId,
	a.FirstName + ' ' + a.LastName AS FullName,
	MAX(DATEDIFF(day, ArrivalDate, ReturnDate)),
	MIN(DATEDIFF(day, ArrivalDate, ReturnDate))
FROM Accounts AS a
	JOIN AccountsTrips AS atr ON atr.AccountId = a.Id
	JOIN Trips AS t ON t.Id = atr.TripId
WHERE MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY a.Id, a.FirstName, a.LastName
ORDER BY MAX(DATEDIFF(day, ArrivalDate, ReturnDate)) DESC, MIN(DATEDIFF(day, ArrivalDate, ReturnDate))



--**************************PROBLEM 8 - Metropolis *******************************
SELECT TOP(10) c.Id, c.Name AS City, c.CountryCode AS Country, COUNT(acc.Id) AS Accounts FROM Cities AS c
JOIN Accounts AS acc ON acc.CityId = c.Id
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY COUNT(acc.Id) DESC


--**************************PROBLEM 9 - Romantic Getaways *******************************
SELECT a.Id, a.Email, c.Name AS City, COUNT(t.Id) FROM Accounts AS a
	JOIN AccountsTrips AS accTr ON accTr.AccountId = a.Id
	JOIN Trips AS t ON t.Id = accTr.TripId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS c ON a.CityId = c.Id AND h.CityId = c.Id
GROUP BY a.Id, a.Email, c.Name
ORDER BY COUNT(t.Id) DESC, a.Id


--**************************PROBLEM 10 - GDPR Violation *******************************
SELECT 
t.Id,
CASE
	WHEN a.MiddleName IS NULL THEN a.FirstName + ' ' + a.LastName
	ELSE a.FirstName + ' ' + a.MiddleName + ' ' + a.LastName
END AS [Full Name],
c.[Name] AS [From],

-- TODO Add city to hotel relation 
(SELECT cc.Name FROM Trips AS tt
	JOIN AccountsTrips AS accT2 ON accT2.TripId = tt.Id
	JOIN Accounts AS aa ON aa.Id = accT2.AccountId
	JOIN Rooms AS rr ON rr.Id = tt.RoomId
	JOIN Hotels AS hh ON hh.Id = rr.HotelId
	JOIN Cities AS cc ON hh.CityId = cc.Id
WHERE tt.Id = t.Id AND a.Id = aa.Id AND hh.Id = h.Id) AS [To]
,
CASE 
WHEN CancelDate IS NOT NULL THEN 'Canceled'
ELSE  CONVERT (NVARCHAR, DATEDIFF(DAY, CONVERT(date, ArrivalDate), CONVERT(date,ReturnDate))) + ' days'
END AS Duration

FROM Trips AS t
	JOIN AccountsTrips AS accT ON accT.TripId = t.Id
	JOIN Accounts AS a ON a.Id = accT.AccountId
	JOIN Cities AS c ON c.Id = a.CityId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
ORDER BY [Full Name], t.Id

--**************************PROBLEM 11 - Available Room *******************************
-- Solution by Boyan Kuzmanov (better than mine :} )
GO

CREATE FUNCTION udf_GetAvailableRoom (@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN

 DECLARE @RoomId INT = (SELECT TOP(1) r.Id FROM Trips AS t
						JOIN Rooms AS r ON t.RoomId = r.Id
						JOIN Hotels AS h ON r.HotelId = h.Id
						WHERE h.Id = @HotelId 
						  AND @Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate 
						  AND t.CancelDate IS NULL
						  AND r.Beds >= @People
						  AND YEAR(@Date) = YEAR(t.ArrivalDate)
						  ORDER BY r.Price DESC)

  IF @RoomId IS NULL
	RETURN 'No rooms available'

  DECLARE @RoomPrice DECIMAL(15,2) = (SELECT Price FROM Rooms WHERE Id = @RoomId)

  DECLARE @RoomType VARCHAR (50)  = (SELECT [Type] FROM Rooms WHERE Id = @RoomId)

  DECLARE @BedsCount INT  = (SELECT Beds FROM Rooms WHERE Id = @RoomId)

  DECLARE  @HotelBaseRate DECIMAL(15,2) = (SELECT BaseRate FROM Hotels WHERE Id = 112)
  
  DECLARE @TotalPrice DECIMAL(15, 2) =  (@HotelBaseRate + @RoomPrice) * @People

RETURN CONCAT('Room ',@RoomId,': ', @RoomType,' (',@BedsCount,' beds',') - $',@TotalPrice)
RETURN 'Room ' + CONVERT(NVARCHAR,@RoomId) 
		+ ': ' + CONVERT(NVARCHAR, @RoomType) 
		+ ' (' + CONVERT(NVARCHAR, @BedsCount) 
		+ ' beds)' 
		+ ' - $' 
		+ CONVERT(NVARCHAR, @TotalPrice)
END

--**************************PROBLEM 12 - Switch Room *******************************
CREATE ALTER PROCEDURE usp_SwitchRoom @TripId INT, @TargetRoomId INT
AS
BEGIN
DECLARE @RoomHotelId INT = (SELECT TOP(1) h.Id FROM Trips AS t
       JOIN Rooms AS r ON r.Id = t.RoomId
       JOIN HOTELS AS h ON h.Id = r.HotelId
       WHERE t.Id = @TripId)

DECLARE @HotelId INT = (SELECT HotelId FROM Rooms WHERE @TargetRoomId = Id)

DECLARE @BedsCount INT = (SELECT Beds FROM Rooms WHERE @TargetRoomId = Id)

DECLARE @AccoutTripsCount INT = (SELECT COUNT(*) FROM AccountsTrips WHERE TripId = @TripId)

  IF @RoomHotelId != @HotelId
           THROW 50001, 'Target room is in another hotel!', 1
 
  ELSE IF @BedsCount < @AccoutTripsCount      
           THROW 50002, 'Not enough beds in target room!', 1
              
  ELSE       
	BEGIN
        UPDATE Trips
            SET RoomId = @TargetRoomId
            WHERE Id = @TripId
	END
END

--EXEC usp_SwitchRoom 10, 11
--SELECT RoomId FROM Trips WHERE Id = 10
--EXEC usp_SwitchRoom 10, 7
--EXEC usp_SwitchRoom 10, 8