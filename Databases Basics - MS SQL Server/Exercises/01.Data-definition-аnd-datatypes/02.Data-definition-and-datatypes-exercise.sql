-- Problem 1
CREATE DATABASE [Minions]

USE [Minions]

-- Problem 2
CREATE TABLE [Minions] (
Id INT PRIMARY KEY NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
[Age] TINYINT NOT NULL
)

CREATE TABLE [Towns](
Id INT PRIMARY KEY NOT NULL,
[Name] NVARCHAR(50) NOT NULL
)

-- Problem 3
ALTER TABLE [Minions]
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

-- Problem 4
INSERT INTO Towns(Id, [Name])
VALUES 
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')
 

 INSERT INTO Minions(Id, [Name], Age, TownId)
 VALUES
 (1, 'Kevin', 22,1),
 (2, 'Bob', 15, 3),
 (3, 'Steward', NULL, 2)

 -- Problem 5
 TRUNCATE TABLE [Minions]

 -- Problem 6
 DROP TABLE [Minions]
 DROP TABLE [Towns]
 

 -- PROBLEM 7
 CREATE TABLE People(
 Id INT PRIMARY KEY IDENTITY, 
 [Name] NVARCHAR(200) NOT NULL,
 Picture VARBINARY(MAX) CHECK (DATALENGTH(Picture) > 1024 * 1024 *2 ),
 Height DECIMAL(3,2),
 [Weight] DECIMAL (5,2),
 Gender CHAR(1) CHECK(Gender ='m' OR Gender = 'f') NOT NULL,
 Birthdate DATE NOT NULL,
 Biography NVARCHAR(MAX) 
 )
 
 INSERT INTO People (Name, Picture, Height, [Weight], Gender, Birthdate, Biography)
 VALUES
 ('Ivan O', NULL, 1.24, 55.00, 'm', CONVERT(DateTime, '20000525', 112),'Mamuna'), 
 ('Ivan X', NULL, 1.44, 55.00, 'm', CONVERT(DateTime, '20000515', 112),'Kosmos'),
 ('Ivan Y', NULL, 1.54, 55.00, 'm', CONVERT(DateTime, '20000512', 112),'Shklyokavitsa'),
 ('Ivan Z', NULL, 1.64, 55.00, 'm', CONVERT(DateTime, '20000522', 112),'Металотърсач'),
 ('Ivan F', NULL, 1.74, 55.00, 'm', CONVERT(DateTime, '20000523', 112),'Прожектор')


 -- Problem 8
CREATE TABLE Users(
Id BIGINT IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX) CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
LastLoginTime DATETIME,
IsDeleted BIT
CONSTRAINT PK_Users PRIMARY KEY(Id)
)

INSERT INTO Users VALUES
('Gosho', '21512', NULL, NULL, 0),
('Ivan', '21513', NULL, NULL, 1),
('Ivgo', '21514', NULL, NULL, 0),
('Goiv', '21515', NULL, NULL, 1),
('Ogvi', '21516', NULL, NULL, 0)

-- PROBLEM 9
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username)\

-- PROBLEM 10
ALTER TABLE Users
ADD CONSTRAINT PasswordCheck CHECK(LEN([Password]) >=5)

-- PROBLEM 11

ALTER TABLE Users
ADD CONSTRAINT Default_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

-- PROBLEM 12 
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_UserId PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT DF_UsernameLength CHECK(LEN(Username) >=3)

DROP DATABASE Minions
-- PROBLEM 13
CREATE DATABASE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(200) 
)

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR (30) NOT NULL,
Notes NVARCHAR(200) 
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(150)
)

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(30) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
CopyrightYear INT NOT NULL,
[Length] TIME, 
GenreId INT FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Rating DECIMAL(2,1),
Notes NVARCHAR(MAX)
)

INSERT INTO Directors VALUES
('Ivan Ivanov', 'Golden boot Winner'),
('Stan Petrov', 'Multiple international awards'),
('James Cameron', 'FC Liverpool legend'),
('Sam Mayor', 'MK3 World Champion'),
('Dany De La Hoya', 'Very talented')

INSERT INTO Genres VALUES
('Comedy', 'Very funny...'),
('Action', 'Weapons mepons'),
('Horror', 'Not for children'),
('SciFi', 'Space and aliens'),
('Drama', 'OMG')

INSERT INTO Categories VALUES
('1', NULL),
('2', NULL),
('3', NULL),
('4', NULL),
('5', NULL)

INSERT INTO MOVIES VALUES
('Gosho and the others', 1, 2020, '1:25:00', 1, 1, 9.9, 'Must watch it with popcorns and wiskey') 

INSERT INTO Movies VALUES
('Hmm part 2', 1, 1999, '1:40:00', 2, 4, 5.0, 'SAW'),
('The naked cat', 2, 2999, '1:11:21', 3, 3, 5.3, 'WAS'),
('Joe and his women', 4, 2999, '2:12:21', 4, 2, 5.8, 'Whiskey in the Jar'),
('Mad cat', 3, 2098, '1:30:01', 5, 1, 2.9, 'Rating 10 not supported') 

--PROBLEM 14
CREATE DATABASE CarRental

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate INT NOT NULL,
	WeeklyRate INT NOT NULL,
	MonthlyRate INT NOT NULL,
	WeekendRate INT NOT NULL
)

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(20) NOT NULL UNIQUE,
	Manufacturer NVARCHAR(30) NOT NULL,
	Model NVARCHAR(30) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors INT,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(500),
	Available BIT NOT NULL
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(30),
	Notes NVARCHAR(500)
)

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber NVARCHAR(20) NOT NULL UNIQUE,
	FullName NVARCHAR(100) NOT NULL,
	Address NVARCHAR(250) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	ZIPCode NVARCHAR(30),
	Notes NVARCHAR(1000) 
)

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage AS KilometrageEnd - KilometrageStart,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
	RateApplied INT NOT NULL,
	TaxRate AS RateApplied * 0.2,
	OrderStatus BIT NOT NULL,
	Notes NVARCHAR(1000)
)

INSERT INTO Categories VALUES
('Limousine', 65, 350, 1350, 120),
('SUV', 85, 500, 1800, 160),
('Economic', 40, 230, 850, 70)

INSERT INTO Cars VALUES
('B8877PP', 'Audi', 'A6', 2001, 1, 4, NULL, 'Good', 1),
('GH17GH78', 'Opel', 'Corsa', 2014, 3, 5, NULL, 'Very good', 0),
('CT17754GT', 'VW', 'Touareg', 2008, 2, 5, NULL, 'Zufrieden', 1)

INSERT INTO Employees VALUES
('Stancho', 'Mihaylov', NULL, NULL),
('Doncho', 'Petkov', NULL, NULL),
('Stamat', 'Jelev', 'DevOps', 'Employee of the year')

INSERT INTO Customers(DriverLicenceNumber, FullName, Address, City) VALUES
('AZ18555PO', 'Michael Smith', 'Medley str. 25', 'Chikago'),
('LJ785554478', 'Sergey Ivankov', 'Shtaigich 37', 'Perm'),
('LK8555478', 'Franc Joshua', 'Dorcel str. 56', 'Paris')

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, 
StartDate, EndDate, RateApplied, OrderStatus) VALUES
(1, 2, 3, 45, 18005, 19855, '2007-08-08', '2007-08-10', 250, 1),
(3, 2, 1, 50, 55524, 56984, '2009-09-06', '2009-09-28', 1500, 0),
(2, 2, 1, 18, 36005, 38547, '2017-05-08', '2017-06-09', 850, 0)


--PROBLEM 15
CREATE DATABASE Hotel

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(500)
)

CREATE TABLE Customers (
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	PhoneNumber NVARCHAR(30),
	EmergencyName NVARCHAR(30),
	EmergencyNumber NVARCHAR(30),
	Notes NVARCHAR(500) 
)

CREATE TABLE RoomStatus (
	RoomStatus NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(500)
)

CREATE TABLE RoomTypes (
	RoomType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(500)
)

CREATE TABLE BedTypes (
	BedType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(500)
)

CREATE TABLE Rooms (
	RoomNumber INT PRIMARY KEY NOT NULL,
	RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
	BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
	Rate DECIMAL(6,2) NOT NULL,
	RoomStatus BIT NOT NULL,
	Notes NVARCHAR(1000)
)

CREATE TABLE Payments (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
	AmountCharged DECIMAL(7, 2) NOT NULL,
	TaxRate DECIMAL(6,2) NOT NULL,
	TaxAmount AS AmountCharged * TaxRate,
	PaymentTotal AS AmountCharged + AmountCharged * TaxRate,
	Notes NVARCHAR(1500)
)

CREATE TABLE Occupancies (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	DateOccupied DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
	RateApplied DECIMAL(7, 2) NOT NULL,
	PhoneCharge DECIMAL(8, 2) NOT NULL,
	Notes NVARCHAR(1000)
)

INSERT INTO Employees(FirstName, LastNAme) VALUES
('Ivo', 'T'),
('Ivan', 'G'),
('Ivelin', 'F')

INSERT INTO Customers(FirstName, LastName, PhoneNumber) VALUES
('A', 'E', '+359888666555'),
('Z', 'Q', '+359866444222'),
('W', 'R', '+35977555333')

INSERT INTO RoomStatus(RoomStatus) VALUES
('occupied'),
('non occupied'),
('almost occupied')

INSERT INTO RoomTypes(RoomType) VALUES
('single'),
('double'),
('appartment')

INSERT INTO BedTypes(BedType) VALUES
('single'),
('double'),
('couch')

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus) VALUES
(111, 'single', 'single', 20.0, 1),
(112, 'double', 'double', 30.0, 0),
(132, 'appartment', 'double', 10.0, 1)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate) VALUES
(3, '2011-11-25', 2, '2017-11-30', '2017-12-04', 250.0, 0.2),
(2, '2014-06-03', 3, '2014-06-06', '2014-06-09', 340.0, 0.2),
(1, '2016-02-25', 2, '2016-02-27', '2016-03-04', 500.0, 0.2)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge) VALUES
(2, '2015-01-01', 2, 111, 70.0, 12.54),
(2, '2017-01-02', 3, 112, 40.0, 11.22),
(3, '2018-01-03', 1, 132, 110.0, 10.05)


-- PROBLEM 16
CREATE DATABASE SoftUni

CREATE TABLE Towns (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses (
Id INT PRIMARY KEY IDENTITY,
AddressText NVARCHAR(120) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY, 
FirstName NVARCHAR(50) NOT NULL, 
MiddleName NVARCHAR(50) NOT NULL, 
LastName NVARCHAR(50) NOT NULL, 
JobTitle NVARCHAR(50) NOT NULL, 
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL, 
HireDate DATE, 
Salary DECIMAL(8,2), 
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

-- Problem 17
BACKUP DATABASE SoftUni TO DISK = 'C:\Users\q2kfo\OneDrive\Desktop\DB RESTORE\softuni-backup.bak'

-- Problem 18
INSERT INTO Towns([Name])
VALUES
('Sofia'), 
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)

-- Problem 19
SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

-- Problem 20
SELECT * FROM Towns ORDER BY [Name]
SELECT * FROM Departments ORDER BY [Name]
SELECT * FROM Employees ORDER BY Salary DESC

-- Problem 21
SELECT [Name] FROM Towns ORDER BY [Name]
SELECT [Name] FROM Departments ORDER BY [Name]
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC

-- Problem 22
UPDATE Employees
SET Salary *= 1.1

SELECT Salary FROM Employees

--Problem 23
USE Hotel
UPDATE Payments
SET TaxRate -= TaxRate*0.03
SELECT TaxRate FROM Payments

--Problem 24
TRUNCATE TABLE Occupancies