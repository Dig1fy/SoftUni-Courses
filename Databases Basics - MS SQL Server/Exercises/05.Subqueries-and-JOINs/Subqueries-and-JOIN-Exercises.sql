--Problem 1.	Employee Address

SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText 
	FROM Employees AS e
	JOIN Addresses AS a ON  e.AddressID = a.AddressID
	ORDER BY e.AddressID

--Problem 2.	Addresses with Towns
SELECT TOP(50) e.FirstName, e.LastName, t.Name AS Town, a.AddressText 
	FROM Employees as e
	JOIN Addresses AS a ON a.AddressID=e.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
	ORDER BY FirstName, LastName

--Problem 3.	Sales Employee
SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name AS DepartmentName
	FROM Employees as e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE d.Name='Sales'
	ORDER BY e.EmployeeID

--Problem 4.	Employee Departments
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name AS DepartmentName
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary>15000
	ORDER BY e.DepartmentID

--Problem 5.	Employees Without Project
SELECT DISTINCT TOP(3) e.EmployeeID, e.FirstName FROM Employees AS e
	RIGHT JOIN EmployeesProjects AS ep 
	ON e.EmployeeID NOT IN (SELECT DISTINCT EmployeeID FROM EmployeesProjects)
	ORDER BY e.EmployeeID

--Problem 6.	Employees Hired After
SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE e.HireDate > 1999/01/01 AND d.Name IN ('Sales', 'Finance')
	ORDER BY e.HireDate

--Problem 7.	Employees with Project
SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name AS ProjectName FROM Employees AS e 
	JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
	JOIN Projects AS p ON p.ProjectID = ep.ProjectID
	WHERE p.StartDate > '2002/08/13' AND p.EndDate IS NULL 
	ORDER BY e.EmployeeID
		
--Problem 8.	Employee 24
SELECT e.EmployeeID, e.FirstName, 
	CASE 
		WHEN p.StartDate >= '2005-01-01' THEN NULL
		ELSE p.Name
	END AS ProjectName
FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p ON p.ProjectID = ep.ProjectID
	WHERE e.EmployeeID = 24

--Problem 9.	Employee Manager
SELECT 
	e.EmployeeID, e.FirstName, e.ManagerID, e2.FirstName
	AS ManagerName FROM Employees AS e
		JOIN Employees AS e2 ON e.ManagerID = e2.EmployeeID
		WHERE e.ManagerID IN (3,7) 
		ORDER BY e.EmployeeID

--Problem 10.	Employee Summary
SELECT TOP(50)
	e.EmployeeID,
	e.FirstName + ' ' + e.LastName AS EmployeeName,
	e2.FirstName + ' ' + e2.LastName AS ManagerName,
	d.Name AS DepartmentName
FROM Employees AS e
	JOIN Employees AS e2 ON e2.EmployeeID = e.ManagerID
	JOIN Departments AS d ON d.DepartmentID= e.DepartmentID
	ORDER BY e.EmployeeID

--Problem 11.	Min Average Salary
SELECT TOP(1) MinAverageSalary FROM 
	(SELECT AVG(Salary) AS MinAverageSalary 
		FROM Employees 
		GROUP BY DepartmentID)
		AS AvgSalaries
		ORDER BY MinAverageSalary 

--Problem 12.	Highest Peaks in Bulgaria
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation FROM Countries AS c
	JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	JOIN Mountains AS m ON m.Id = mc.MountainId
	JOIN Peaks AS p ON m.Id = p.MountainId
	WHERE p.Elevation > 2835 AND c.CountryCode = 'BG'
	ORDER BY p.Elevation DESC

--Problem 13.	Count Mountain Ranges
SELECT CountryCode, COUNT(MountainId) AS MountainRanges FROM MountainsCountries	
	WHERE CountryCode IN ('US', 'BG', 'RU')
	GROUP BY CountryCode

--Problem 14.	Countries with Rivers
SELECT TOP(5) c.CountryName, r.RiverName FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
	WHERE c.ContinentCode = 'AF'
	ORDER BY c.CountryName	

--Problem 15.	*Continents and Currencies - UNFINISHED
--SELECT * FROM	(SELECT ContinentCode, CurrencyCode, [CurrencyCount], DENSE_RANK() OVER
--	(PARTITION BY ContinentCode ORDER BY CurrencyCount DESC) as CurrencyRank FROM
--			(SELECT ContinentCode, CurrencyCode, COUNT(*) as CurrencyCount FROM Countries
--			GROUP BY ContinentCode, CurrencyCode) AS CurrencyCountQuery)

--Problem 16.	Countries without any Mountains

SELECT COUNT(c.CountryCode) AS Count FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc 
	ON c.CountryCode = mc.CountryCode
	WHERE mc.MountainId IS NULL 
	
--Problem 17.	Highest Peak and Longest River by Country
	SELECT TOP(5)
		 c.CountryName, MAX(p.Elevation) AS HighestPeakElevation,
		 MAX(r.Length) AS LongestRiverLength FROM Countries AS c
			LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
			LEFT JOIN Rivers AS r ON cr.RiverId = r.Id 
			LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
			LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
			LEFT JOIN Peaks AS p ON mc.MountainId = p.MountainId
		 GROUP BY c.CountryName
		 ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName

--Problem 18.	* Highest Peak Name and Elevation by Country - BROKEN
	
	SELECT *,
		DENSE_RANK() OVER (PARTITION BY [Country] ORDER BY [Highest Peak Name]DESC) AS DRank
		INTO #TZ FROM
	        (SELECT 
	        c.CountryName AS Country,
	        ISNULL(PeakName, '(no highest peak)' ) AS [Highest Peak Name],
			ISNULL(Elevation, 0) AS  [Highest Peak Elevation],
	        ISNULL(MountainRange, '(no mountain)') AS Mountain 
	        FROM Countries AS c		
	        		LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	        		LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	        		LEFT JOIN Peaks AS p ON mc.MountainId = p.MountainId
				) AS [FullQueryInfo]
				
		SELECT TOP(5) Country, [Highest Peak Name], [Highest Peak Elevation], Mountain 
		FROM #TZ WHERE DRank = 1