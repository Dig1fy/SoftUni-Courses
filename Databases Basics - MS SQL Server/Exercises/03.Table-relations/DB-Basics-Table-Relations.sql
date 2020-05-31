--PROBLEM 1 - One-To-One Relationship
CREATE TABLE Passports(
PassportID INT PRIMARY KEY NOT NULL,
PassportNumber CHAR(8) NOT NULL
)

CREATE TABLE Persons (
PersonID INT PRIMARY KEY NOT NULL IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
Salary DECIMAL(7,2) NOT NULL,
PassportID INT NOT NULL FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE
)

 INSERT INTO Passports (PassportID, PassportNumber) VALUES
 (101,'N34FG21B'),
 (102,'K65LO4R7'),
 (103,'ZE657QP2') 

INSERT INTO Persons ([FirstName], Salary, PassportID) VALUES
 ('Roberto', 43300, 102),
 ('Tom', 56100, 103),
 ('Yana', 60200, 101)

--PROBLEM 2 - One-To-Many Relationship
CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR (50) NOT NULL,
EstablishedOn DATE NOT NULL
)

CREATE TABLE Models(
ModelID INT PRIMARY KEY IDENTITY(101,1),
[Name] NVARCHAR(25) NOT NULL,
ManufacturerID INT NOT NULL FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

INSERT INTO Models VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)

--PROBLEM 3 - Many-To-Many Relationship
CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(25)
)

CREATE TABLE Exams(
ExamID INT PRIMARY KEY IDENTITY(101, 1),
[Name] NVARCHAR(25) NOT NULL
)

CREATE TABLE StudentsExams(
StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
ExamID INT FOREIGN KEY REFERENCES Exams(ExamID) NOT NULL,
CONSTRAINT PK_Students_Exams PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO Students VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO StudentsExams VALUES
(1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103)

--PROBLEM 4 - Self-Referencing
CREATE TABLE Teachers(
TeacherID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
[Name] NVARCHAR(25) NOT NULL,
ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

--PROBLEM 5 - Online Store Database
CREATE TABLE Cities(
CityID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50)
)

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50),
Birthday DATE,
CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
OrderID INT PRIMARY KEY IDENTITY,
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes(
ItemTypeID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50)
)

CREATE TABLE Items(
ItemID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50),
ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems(
OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
CONSTRAINT FK_Orders_Items PRIMARY KEY (OrderID, ItemID)
)

--PROBLEM 6 - University Database
CREATE DATABASE UniversityDatabase

CREATE TABLE Majors(
MajorID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50)
)

CREATE TABLE Subjects (
SubjectID INT PRIMARY KEY IDENTITY,
SubjectName VARCHAR(50)
)

CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY,
StudentNumber INT NOT NULL,
StudentName VARCHAR(50) NOT NULL,
MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Agenda(
StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
CONSTRAINT FK_Students_Subjects PRIMARY KEY(StudentID, SubjectID)
)
 
CREATE TABLE Payments(
PaymentID INT PRIMARY KEY IDENTITY,
PaymentDate DATE,
PaymentAmount DECIMAL (7,2) NOT NULL,
StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

--PROBLEM 9 - Peaks in Rila
SELECT Mountains.MountainRange, Peaks.PeakName, Peaks.Elevation FROM Mountains
JOIN Peaks ON Peaks.MountainId = Mountains.Id
WHERE Mountains.MountainRange = 'Rila'
ORDER BY Peaks.Elevation DESC