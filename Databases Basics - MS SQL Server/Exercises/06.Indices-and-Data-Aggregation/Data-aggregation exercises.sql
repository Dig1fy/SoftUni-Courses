--Problem 1.	Records’ Count\
--USE Gringotts
SELECT COUNT(*) AS Count FROM WizzardDeposits

--Problem 2.	Longest Magic Wand
SELECT MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits

--Problem 3.	Longest Magic Wand per Deposit Groups
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits
GROUP BY DepositGroup 

--Problem 4.	* Smallest Deposit Group per Magic Wand Size
SELECT TOP(2) DepositGroup FROM WizzardDeposits 
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

--Problem 5.	Deposits Sum
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
GROUP BY DepositGroup

--Problem 6.	Deposits Sum for Ollivander Family
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--Problem 7.	Deposits Filter
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--Problem 8.	Deposit Charge
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--Problem 9.	Age Groups
SELECT a.AgeGroup, COUNT(*) AS WizardCount FROM
	(SELECT 
		CASE
		WHEN Age <= 10 THEN '[0-10]'
		WHEN Age <= 20 THEN '[11-20]'
		WHEN Age <= 30 THEN '[21-30]'
		WHEN Age <= 40 THEN '[31-40]'
		WHEN Age <= 50 THEN '[41-50]'
		WHEN Age <= 60 THEN '[51-60]'
		ELSE '[61+]'
		END AS AgeGroup
		FROM WizzardDeposits) AS a
	GROUP BY a.AgeGroup
	ORDER BY a.AgeGroup
	
--Problem 10.	First Letter
SELECT  LEFT(FirstName, 1) AS FirstLetter FROM WizzardDeposits
WHERE DepositGroup LIKE 'Troll%'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter

--Problem 11.	Average Interest 
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest FROM WizzardDeposits
WHERE DepositStartDate > '1985/01/01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

--Problem 12.	* Rich Wizard, Poor Wizard
SELECT ABS(SUM(tt.DepositDifference)) AS SumDifference FROM 
	(SELECT wiz1.DepositAmount - wiz2.DepositAmount AS DepositDifference 
	 FROM WizzardDeposits AS wiz1
	 JOIN WizzardDeposits AS wiz2 ON wiz1.Id = (wiz2.Id + 1)) AS tt	 

--Problem 13.	Departments Total Salaries
-- USE SoftUni
SELECT DepartmentId, SUM(Salary) AS TotalSalary FROM Employees
GROUP BY DepartmentID

--Problem 14.	Employees Minimum Salaries
SELECT DepartmentID, MIN(Salary) AS MinimumSalary FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate > '2000/01/01'
GROUP BY DepartmentID

--Problem 15.	Employees Average Salaries
SELECT *
INTO #tempTable
FROM Employees
WHERE Salary > 30000

DELETE FROM #tempTable
WHERE ManagerID = 42

UPDATE #tempTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary FROM #tempTable
GROUP BY DepartmentID

--Problem 16.	Employees Maximum Salaries
SELECT DepartmentID, MAX(Salary) FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--Problem 17.	Employees Count Salaries
SELECT COUNT(Salary) AS Count FROM Employees
WHERE ManagerID IS NULL

--Problem 18.	*3rd Highest Salary
SELECT tt.DepartmentID, tt.Salary AS ThirdHighestSalary
	FROM
		(SELECT DepartmentID, Salary,
		DENSE_RANK() OVER   
		(PARTITION BY DepartmentID ORDER BY Salary DESC) AS OrderedSalaries
		FROM Employees ) AS tt 
	WHERE OrderedSalaries = 3
	GROUP BY tt.DepartmentID, tt.Salary

--Problem 19.	**Salary Challenge
SELECT TOP(10) FirstName, LastName, DepartmentID FROM Employees AS e1
WHERE Salary >
	(SELECT AVG(Salary) FROM Employees AS e2
	 WHERE e1.DepartmentID = e2.DepartmentID)
ORDER BY DepartmentID