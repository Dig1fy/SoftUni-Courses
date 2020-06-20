-- ******************************* Problem 1 - DDL ******************************* --
--CREATE DATABASE Bitbucket

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) NOT NULL,
	[Password] NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT REFERENCES Users(Id) NOT NULL
	CONSTRAINT PK_RepositoriesContributors PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(255) NOT NULL,
	IssueStatus NVARCHAR(6) NOT NULL,
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits(
	Id INT PRIMARY KEY IDENTITY,
	[Message] NVARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	Size DECIMAL(10,2) NOT NULL,
	ParentId INT REFERENCES Files(Id),
	CommitId INT REFERENCES Commits(Id) NOT NULL
)


-- ******************************* Problem 2 - Insert ******************************* --
INSERT INTO Files ([Name], Size, ParentId, CommitId) VALUES
	('Trade.idk', 2598.0, 1, 1),
	('menu.net', 9238.31, 2, 2),
	('Administrate.soshy', 1246.93, 3, 3),
	('Controller.php', 7353.15, 4, 4),
	('Find.java', 9957.86, 5, 5),
	('Controller.json', 14034.87, 3, 6),
	('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues (Title, IssueStatus, RepositoryId, AssigneeId) VALUES
('Critical Problem with HomeController.cs file', 'open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)


-- ******************************* Problem 3 - Update ******************************* --
UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = '6'


-- ******************************* Problem 4 - Delete ******************************* --
DELETE FROM RepositoriesContributors
	WHERE RepositoryId = 3

DELETE FROM Issues 
	WHERE RepositoryId = 3


-- ******************************* Problem 5 - Commits ******************************* --
SELECT Id, [Message], RepositoryId, ContributorId FROM Commits
	ORDER BY Id, [Message], RepositoryId, ContributorId


-- ******************************* Problem 6 - Heavy HTML ******************************* --
SELECT Id, [Name], Size FROM Files
	WHERE Size > 1000 AND [Name] LIKE '%html%'
	ORDER BY Size DESC, Id, [Name]


-- ******************************* Problem 7 - Issues and Users ******************************* --
SELECT i.Id, u.Username + ' : ' + i.Title AS IssueAssignee FROM Issues AS i
	JOIN Users AS u ON u.Id = i.AssigneeId	
	ORDER BY i.Id DESC, i.AssigneeId


-- ******************************* Problem 8 - Non-Directory Files ******************************* --
SELECT c.Id ,c.[Name], CONVERT(Varchar, c.Size)+'KB' AS Size FROM Files AS c
	LEFT JOIN Files AS cc ON cc.ParentId = c.Id
	WHERE cc.ParentId IS NULL
	ORDER BY c.Id, c.[Name], c.Size DESC


-- ******************************* Problem 9 - Most Contributed Repositories ******************************* --
SELECT TOP(5) r.Id, r.Name, COUNT(*) FROM Commits AS c
	JOIN Repositories AS r ON r.Id = c.RepositoryId
	JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
	GROUP BY r.Id, r.Name
	ORDER BY COUNT(*) DESC, r.Id, r.Name


-- ******************************* Problem 10 - User and Files ******************************* --
SELECT u.Username, AVG(f.Size) AS Size FROM Users AS u 
	JOIN Commits AS c ON c.ContributorId = u.Id
	JOIN Files AS f ON f.CommitId = c.Id
	GROUP BY u.Username
	ORDER BY AVG(f.Size) DESC, u.Username


-- ******************************* Problem 11 - User Total Commits ******************************* --
CREATE FUNCTION udf_UserTotalCommits(@username NVARCHAR(30)) 
RETURNS INT AS
BEGIN
	DECLARE @result INT;  

	SELECT @result =  COUNT(c.Id) FROM Users AS u 
	JOIN Commits AS c ON c.ContributorId = u.Id
	WHERE u.Username = @username

	RETURN @result
END

--SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')

-- ******************************* Problem 12 - Find by Extensions ******************************* --

CREATE PROC usp_FindByExtension(@extension NVARCHAR(10)) AS
BEGIN
	SELECT Id, [Name], CONVERT(VARCHAR, Size) + 'KB' AS Size FROM Files AS f
	WHERE f.[Name] LIKE '%'+ @extension
	ORDER BY Id, [Name], f.Size DESC
END

--EXEC usp_FindByExtension 'txt'