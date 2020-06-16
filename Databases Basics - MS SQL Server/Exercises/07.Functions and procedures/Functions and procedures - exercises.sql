--1.	Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000 AS
	SELECT FirstName, LastName FROM Employees
	WHERE Salary > 35000

--2.	Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@Salary DECIMAL(18,4)) AS
	SELECT FirstName, LastName FROM Employees
	WHERE Salary >= @Salary

--3.	Town Names Starting With
CREATE PROC usp_GetTownsStartingWith(@Start NVARCHAR(20)) AS
	SELECT Name AS Town FROM Towns 
	WHERE Name LIKE @Start + '%'

--Do not paste this in Judge. It's for testing purpose only.
EXEC usp_GetTownsStartingWith b

--4.	Employees from Town
CREATE PROC usp_GetEmployeesFromTown(@Town NVARCHAR(50)) AS 
	SELECT FirstName, LastName FROM Employees AS e
	JOIN Addresses AS a 
		ON e.AddressID = a.AddressID
	JOIN Towns AS t 
		ON t.TownID = a.TownID
	WHERE t.Name = @Town

--Do not paste this in Judge. It's for testing purpose only.
EXEC usp_GetEmployeesFromTown sofia

--5.	Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4)) 
RETURNS NVARCHAR(20) AS
BEGIN
	DECLARE @CurrentSalary NVARCHAR(25)
	SET @CurrentSalary = 
	CASE
		WHEN @Salary < 30000 THEN 'Low'
		WHEN @Salary <= 50000 THEN 'Average'
		ELSE 'High'		
	END
		RETURN @CurrentSalary
END

--Do not paste this in Judge. It's for testing purpose only.
SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level] FROM Employees

--6.	Employees by Salary Level
CREATE PROC usp_EmployeesBySalaryLevel(@LevelOfSalary NVARCHAR (10)) AS
	SELECT FirstName, LastName FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @LevelOfSalary

--Do not paste this in Judge. It's for testing purpose only.
EXEC usp_EmployeesBySalaryLevel 'High'

--7.	Define Function
CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters NVARCHAR(50), @Word NVARCHAR(100)) 
RETURNS BIT AS
BEGIN

	DECLARE @Index INT= 1;	

	WHILE (@Index <= LEN(@Word))
		BEGIN
			--Check if the @setOfLetters contains the current letter 
			IF CHARINDEX(SUBSTRING(@Word, @Index, 1), @SetOfLetters) = 0 
			BEGIN
				RETURN 0
			END 
				SET @Index += 1;
		END

			RETURN 1
END

--Do not paste this in Judge. It's for testing purpose only.
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob')
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy')

--8.	* Delete Employees and Departments
CREATE PROC usp_DeleteEmployeesFromDepartment (@DepartmentId INT) AS
DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @DepartmentId
						)

 UPDATE Employees
 SET ManagerID = NULL
 WHERE ManagerID IN (
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @DepartmentId
		)

ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL

UPDATE Departments
	SET ManagerID = NULL 
	WHERE DepartmentID = @DepartmentId

DELETE FROM Employees
	WHERE DepartmentID = @DepartmentId

DELETE FROM Departments
	WHERE DepartmentID = @DepartmentId

SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @DepartmentId

--	Queries for Bank Database
--9.	Find Full Name
CREATE PROC usp_GetHoldersFullName AS
SELECT FirstName + ' ' + LastName AS [Full Name] FROM AccountHolders

EXEC usp_GetHoldersFullName

--10.	People with Balance Higher Than
CREATE or alter PROC usp_GetHoldersWithBalanceHigherThan(@TotalMoney MONEY) AS 

	SELECT ah.FirstName, ah.LastName FROM Accounts AS a
	JOIN AccountHolders AS ah
	ON a.AccountHolderId = ah.Id
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @totalMoney

--Do not submit the EXEC. It's for testing purpose only.
EXEC usp_GetHoldersWithBalanceHigherThan 11000

--11.	Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue (@Sum DECIMAL(20,2), @YearlyInterest FLOAT, @Years INT)
RETURNS DECIMAL(20,4) AS
BEGIN
	DECLARE @Result DECIMAL(20,4) = @Sum * POWER((1+@YearlyInterest), @Years)
	RETURN @Result
END

--Check for testing purpose only. Do not submit in Judge
SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

--12.	Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount (@AccID INT, @InterestRate FLOAT)
AS
SELECT 
	a.Id AS [Account Id], 
	ah.FirstName AS [First Name], 
	ah.LastName AS [Last Name], 
	a.Balance AS [Current Balance], 
	dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years] 
FROM AccountHolders AS ah
JOIN Accounts AS a ON a.AccountHolderId=ah.Id AND a.Id = @AccID

--EXEC usp_CalculateFutureValueForAccount 1, 0.1

--Queries for Diablo Database
--13.Scalar Function: Cash in User Games Odd Rows

CREATE FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(155)) 
RETURNS TABLE AS
	RETURN SELECT SUM(Cash) AS SumCash FROM

		(SELECT ug.Cash, ROW_NUMBER() OVER(ORDER BY Cash DESC) AS RowNumber FROM UsersGames AS ug 
		JOIN Games AS g ON ug.GameId = g.Id
		WHERE g.Name = @GameName
		) AS AllGames
		WHERE RowNumber % 2 = 1
	
	--SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')