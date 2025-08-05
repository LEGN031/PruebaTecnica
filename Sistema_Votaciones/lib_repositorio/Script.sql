CREATE DATABASE db_Votos;
GO
USE db_Votos;
GO

CREATE TABLE [Voter] (
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(100) NOT NULL,
	[Email] NVARCHAR(100) NOT NULL UNIQUE,
	[Cedula] NVARCHAR(100) NOT NULL UNIQUE,
	[HasVoted] BIT NOT NULL DEFAULT 0
);

CREATE TABLE [Candidate] (
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(100) NOT NULL,
	[Party] NVARCHAR(100),
	[Cedula] NVARCHAR(100) NOT NULL UNIQUE,
	[Votes] INT NOT NULL DEFAULT 0
);


CREATE TABLE [Vote] (
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Code] NVARCHAR(100) NOT NULL UNIQUE,
	[VoterId] INT NOT NULL,
	FOREIGN KEY ([VoterId]) REFERENCES [Voter]([Id]),
	[CandidateId] INT NOT NULL,
	FOREIGN KEY ([CandidateId]) REFERENCES [Candidate]([Id])
);

INSERT INTO Voter (Name, Email, Cedula)
VALUES
('Laura Martínez', 'laura.martinez@example.com', '1002456789'),
('Carlos Gómez', 'carlos.gomez@example.com', '1013456790'),
('Ana Torres', 'ana.torres@example.com', '1024567891');



INSERT INTO Candidate (Name, Party, Cedula)
VALUES
('María López', 'Partido Verde', '1035678902'),
('Juan Ramírez', 'Partido Azul', '1046789013'),
('Sofía Díaz', 'Independiente', '1057890124');

SELECT * FROM Voter;
SELECT * FROM Candidate;
SELECT * FROM Vote;

