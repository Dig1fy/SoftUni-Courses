-- Database Basics MSSQL Exam – 17 Feb 2019

-- **************************Problem 1 - DDL**************************
CREATE DATABASE School

CREATE TABLE Subjects(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(20) NOT NULL,
Lessons INT NOT NULL 
)

CREATE TABLE Students(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
MiddleName NVARCHAR(20),
LastName NVARCHAR(20) NOT NULL,
Age INT NOT NULL CHECK (Age > 0),
[Address] NVARCHAR(50),
Phone NVARCHAR(10)
)

CREATE TABLE StudentsSubjects(
Id INT PRIMARY KEY IDENTITY,
StudentId INT NOT NULL,
SubjectId INT NOT NULL,
Grade DECIMAL(10,2) NOT NULL CHECK(Grade >= 2 AND Grade <= 6),

CONSTRAINT FK_StudentsProject_Students FOREIGN KEY (StudentId) REFERENCES Students(Id),
CONSTRAINT FK_StudentsProject_Subjects FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)
)

CREATE TABLE Exams(
Id INT PRIMARY KEY IDENTITY,
[Date] DATETIME,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams(
StudentId INT NOT NULL,
ExamId INT NOT NULL,
Grade DECIMAL (15,2) NOT NULL CHECK(Grade >= 2 AND Grade <= 6),

CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentId, ExamId),
CONSTRAINT FK_StudentsExams_Students FOREIGN KEY (StudentId) REFERENCES Students (Id),
CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY (ExamId) REFERENCES Exams(Id)
)

CREATE TABLE Teachers(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Address NVARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers(
StudentId INT NOT NULL,
TeacherId INT NOT NULL,

CONSTRAINT PF_StudentsTeachers PRIMARY KEY (StudentId, TeacherId),
CONSTRAINT FK_StudentsTeachers_Students FOREIGN KEY (StudentId) REFERENCES Students(Id),
CONSTRAINT FK_StudentsTeachers_Teachers FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
)


--**************************PROBLEM 2 - Insert **************************
INSERT INTO Teachers (FirstName, LastName, Address, Phone, SubjectId) VALUES 
('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
('Merrile',	'Lambdin',	'81 Dahle Plaza',	'4373065154',	5),
('Bert',	'Ivie',	'2 Gateway Circle',	'4409584510',	4)

INSERT INTO Subjects ([Name], Lessons) VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)



--**************************PROBLEM 3 - Update**************************
UPDATE StudentsSubjects
SET Grade = 6.00 
WHERE SubjectId IN (1,2) AND Grade >= 5.50

--**************************PROBLEM 4 - Delete**************************
DELETE FROM StudentsTeachers
WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE FROM Teachers
WHERE Phone LIKE '%72%'

--**************************PROBLEM 5 - Teen Students**************************
SELECT FirstName, LastName, Age FROM Students
WHERE Age >= 12 
ORDER BY FirstName, LastName

--**************************PROBLEM 6 - Cool Addresses**************************
SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name], [Address] FROM Students
WHERE [Address] LIKE '%road%'
ORDER BY FirstName, LastName, [Address]

--**************************PROBLEM 7 - 42 Phones**************************
SELECT FirstName, Address, Phone FROM Students
WHERE Phone LIKE '42%' AND MiddleName IS NOT NULL
ORDER BY FirstName

--**************************PROBLEM 8 - Students Teachers**************************
SELECT s.FirstName, s.LastName, COUNT(TeacherId) AS TeachersCount FROM StudentsTeachers AS st
JOIN Students AS s ON st.StudentId = s.Id
GROUP BY FirstName, LastName

--**************************PROBLEM 9 - Subjects with Students**************************
SELECT FullName, Subjects, COUNT(Students) AS Students FROM
	(SELECT
		CONCAT(t.FirstName, ' ', t.LastName) AS [FullName],
		CONCAT(s.Name,'-',s.Lessons ) AS Subjects,
		(st.StudentId) AS Students
		FROM Subjects AS s 
	JOIN Teachers AS t ON s.Id = t.SubjectId
	JOIN StudentsTeachers AS st ON st.TeacherId = t.Id ) AS temp
GROUP BY FullName, Subjects
ORDER BY Students DESC, FullName, Subjects

--**************************PROBLEM 10 - Students to Go**************************
SELECT FirstName + ' ' + LastName AS [Full Name] FROM Students AS s
	LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
	WHERE se.ExamId IS NULL
	ORDER BY [Full Name]

--**************************PROBLEM 11 - Busiest Teachers**************************
SELECT TOP(10) FirstName, LastName, COUNT(st.StudentId) AS StudentsCount 
	FROM Teachers AS t
	JOIN StudentsTeachers AS st 
	ON st.TeacherId = t.Id
GROUP BY FirstName, LastName
ORDER BY StudentsCount DESC, FirstName, LastName

--**************************PROBLEM 12 - Top Students**************************
SELECT TOP(10) FirstName AS [First Name], LastName AS [Last Name], FORMAT(AVG(se.Grade) , 'F2') AS Grade FROM Students AS s
	JOIN StudentsExams AS se 
	ON s.Id = se.StudentId
GROUP BY FirstName, LastName
ORDER BY Grade DESC, FirstName, LastName

--**************************PROBLEM 13 - Second Highest Grade**************************
SELECT FirstName, LastName, Grade 
	FROM 
	   (SELECT s.FirstName, s.LastName, sub.Grade,
		ROW_NUMBER() OVER(PARTITION BY FirstName ORDER BY Grade DESC) AS [GradeRank]
		FROM Students AS s
		JOIN StudentsSubjects AS sub ON sub.StudentId = s.Id) AS temp
WHERE [GradeRank] = 2
ORDER BY FirstName, LastName
	
--**************************PROBLEM 14 - Not So In The Studying**************************
SELECT  
	CASE 
		WHEN s.MiddleName IS NULL THEN s.FirstName + ' ' + s.LastName
		ELSE CONCAT(s.FirstName, ' ', s.MiddleName, ' ', s.LastName)
	END AS [Full Name] 
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId
WHERE SubjectId IS NULL
ORDER BY [Full Name]

--**************************PROBLEM 15 - Top Student by Teacher**************************
SELECT   
	[Teacher Full Name],
	[Subject Name], 
	[Student Full Name], 
	FORMAT(AVG(Grade), 'F2') AS Grade,
	ROW_NUMBER () OVER (PARTITION BY [Teacher Full Name] ORDER BY AVG(Grade) DESC) AS [GradeRank]
	INTO #tempzz
	FROM
		(SELECT 
        t.FirstName + ' ' + t.LastName AS [Teacher Full Name],
        sub.Name AS [Subject Name],
        s.FirstName + ' ' + s.LastName AS [Student Full Name],
        ss.Grade AS Grade		
        
        FROM Teachers AS t 
        	JOIN StudentsTeachers AS st ON t.Id = st.TeacherId
        	JOIN Students AS s ON s.Id = st.StudentId
        	JOIN Subjects AS sub ON sub.Id = t.SubjectId
        	JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id AND ss.SubjectId = sub.Id
			) AS InitialTable

GROUP BY [Subject Name], [Teacher Full Name], [Student Full Name]

SELECT [Teacher Full Name], [Subject Name], [Student Full Name], Grade FROM #tempzz
WHERE GradeRank = 1
ORDER BY [Subject Name], [Teacher Full Name], Grade DESC

--**************************PROBLEM 16 - Average Grade per Subject**************************
SELECT s.Name, AVG(ss.Grade) AS AverageGrade FROM Subjects AS s
	JOIN StudentsSubjects AS ss ON s.Id = ss.SubjectId
	GROUP BY s.Name, SubjectId
	ORDER BY ss.SubjectId
       
--**************************PROBLEM 17 - Exams Information*******************************
SELECT 
  CASE 
    WHEN DATEPART (QUARTER , ex.[Date]) IS NULL THEN 'TBA' 
    ELSE 'Q' + CAST(DATEPART (quarter , ex.[Date]) AS CHAR) 
  END AS [Quarter], 
  sub.Name AS SubjectName, 
  COUNT(*) AS StudentCount 
FROM Subjects AS sub 
  JOIN Exams AS ex ON ex.SubjectId = sub.Id 
  JOIN StudentsExams AS se ON se.ExamId = ex.Id 
  JOIN Students AS s ON s.Id = se.StudentId 
WHERE se.Grade >= 4.00 
GROUP BY  sub.Name, DATEPART(QUARTER , ex.[Date]) 
ORDER BY [Quarter]

--**************************PROBLEM 18 - Exams Information*******************************
CREATE FUNCTION udf_ExamGradesToUpdate(@StudentId INT, @Grade DECIMAL(3,2)) 
RETURNS VARCHAR(100) AS

BEGIN
DECLARE @Count INT = 0;
DECLARE @StudentName NVARCHAR(25);

SELECT @Count = COUNT(*) , @StudentName = s.FirstName FROM Students AS s
JOIN StudentsExams AS se ON s.Id = se.StudentId
WHERE s.Id = @StudentId AND se.Grade BETWEEN @Grade AND @Grade + 0.5
GROUP BY s.FirstName

IF (@Grade > 6.00)
RETURN 'Grade cannot be above 6.00!' 

ELSE IF (@Count = 0)
RETURN 'The student with provided id does not exist in the school!'

ELSE
RETURN 'You have to update ' + CONVERT(VARCHAR, @Count) +  ' grades for the student ' + @StudentName

RETURN ''
END

--SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
--SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
--SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)

--**************************PROBLEM 19 - Exclude from school*******************************
CREATE PROC usp_ExcludeFromSchool (@StudentId INT)
AS
DECLARE @Student INT = 0;

SELECT @Student = s.Id FROM Students AS s
WHERE s.Id = @StudentId

IF (@Student = 0)
THROW 50001, 'This school has no student with the provided id!', 1
	
DELETE FROM StudentsExams
WHERE StudentId = @StudentId

DELETE FROM StudentsSubjects
WHERE StudentId = @StudentId

DELETE FROM StudentsTeachers
WHERE StudentId = @StudentId

DELETE FROM Students
WHERE Id = @StudentId

--**************************PROBLEM 20 - Deleted Student*******************************
--CREATE TABLE ExcludedStudents(
--StudentId INT NOT NULL, 
--StudentName VARCHAR(50) NOT NULL
--)

CREATE TRIGGER tr_DeleteStudent ON Students
INSTEAD OF DELETE
AS
	INSERT INTO ExcludedStudents (StudentId, StudentName )
	SELECT Id, FirstName + ' '+ LastName FROM deleted