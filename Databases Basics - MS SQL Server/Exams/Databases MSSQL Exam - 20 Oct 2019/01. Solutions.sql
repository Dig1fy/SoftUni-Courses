-- ******************************** Problem 1 - DDL ******************************** --
--CREATE DATABASE Service

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) UNIQUE NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50),
	Birthdate DATETIME,
	Age INT CHECK(Age > 14 AND Age <= 110),
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY, 
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK(Age > 18 AND Age <= 110),
	DepartmentId INT REFERENCES Departments(Id) 
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	DepartmentId INT REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status](
	Id INT PRIMARY KEY IDENTITY,
	[Label] NVARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT REFERENCES Categories(Id) NOT NULL,
	StatusId INT REFERENCES Status(Id) NOT NULL,
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	[Description] NVARCHAR(200) NOT NULL,
	UserId INT REFERENCES Users(Id) NOT NULL,
	EmployeeId INT REFERENCES Employees(Id)
)


-- ******************************** Problem 2 - Insert ******************************** --
INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId) VALUES
	('Marlo', 'O''Malley', '1958-9-21', 1), 
	('Niki', 'Stanaghan', '1969-11-26', 4),
	('Ayrton', 'Senna', '1960-03-21', 9),
	('Ronnie', 'Peterson', '1944-02-14', 9),
	('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId) VALUES
	(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
	(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
	(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
	(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)


-- ******************************** Problem 3 - Update ******************************** --
UPDATE Reports
SET CloseDate = DATEPART(year, GETDATE())
WHERE CloseDate IS NULL


-- ******************************** Problem 4 - Delete ******************************** --
DELETE FROM Reports
WHERE StatusId = 4


-- ******************************** Problem 5 - Unassigned Reports ******************************** --
SELECT [Description], FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate 
	FROM Reports AS r 
	WHERE EmployeeId IS NULL
	ORDER BY r.OpenDate, [Description]


-- ******************************** Problem 6 - Reports & Categories ******************************** --
SELECT Description, c.Name AS [Category Name] FROM Reports AS r
	JOIN Categories AS c ON r.CategoryId = c.Id
	WHERE CategoryId IS NOT NULL
	ORDER BY Description, c.Name


-- ******************************** Problem 7 - Most Reported Category ******************************** --
SELECT TOP(5) c.Name AS CategoryName, COUNT(c.Id) AS ReportNumber 
	FROM Categories AS c
	JOIN Reports AS r ON r.CategoryId = c.Id
	GROUP BY c.Name
	ORDER BY COUNT(c.Id) DESC, c.Name


-- ******************************** Problem 8 - Birthday Report ******************************** --
SELECT u.Username, c.Name AS CategoryName FROM Reports AS r
	JOIN Categories AS c ON c.Id = r.CategoryId
	JOIN Users AS u ON u.Id = r.UserId
	WHERE DATEPART(Day, u.Birthdate) = DATEPART(Day, r.OpenDate)
	ORDER BY u.Username, c.Name


-- ******************************** Problem 9 - User per Employee ******************************** --
SELECT e.FirstName + ' ' + e.LastName AS FullName, COUNT(DISTINCT UserId) AS UserCount  FROM Reports AS r
	RIGHT JOIN Employees AS e ON e.Id = r.EmployeeId
	GROUP BY e.FirstName, e.LastName
	ORDER BY COUNT(Distinct UserId) DESC, FullName


-- ******************************** Problem 10 - Full Info ******************************** --
SELECT 
	ISNULL(e.FirstName + ' ' +  e.LastName, 'None') AS Employee,
	ISNULL(dep.Name,'None') AS Department,
	cat.Name AS Category,
	r.Description, 
	FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
	st.Label AS Status,
	ISNULL(u.Name, 'None') [User]

FROM Reports AS r
LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
LEFT JOIN Categories AS cat ON cat.Id = r.CategoryId
LEFT JOIN Departments AS dep ON dep.Id = e.DepartmentId
LEFT JOIN [Status] AS st ON st.Id = r.StatusId
LEFT JOIN Users AS u ON u.Id = r.UserId
ORDER BY e.FirstName DESC, e.LastName DESC, dep.Name, cat.Name, r.Description, r.OpenDate, st.Label, u.Name


-- ******************************** Problem 11 - Hours to Complete ******************************** --
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT AS

BEGIN
	IF @StartDate IS NULL OR @EndDate IS NULL
	RETURN 0

	ELSE
	RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
	RETURN ''
END


-- ******************************** Problem 12 - Assign Employee ******************************** --

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
AS 
BEGIN
DECLARE @EmployeeDepartment INT = (SELECT e.DepartmentId FROM Employees AS e WHERE @EmployeeId = e.Id)


DECLARE @CategoryDepartment INT = (SELECT c.DepartmentId FROM Categories AS c
									JOIN Reports AS r ON r.CategoryId = c.Id
									WHERE @ReportId = r.Id)

IF @EmployeeDepartment != @CategoryDepartment
	THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1

ELSE
	BEGIN
		UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id=@ReportId
	END
END