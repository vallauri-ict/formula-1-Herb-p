CREATE TABLE [dbo].[Circuits]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[name] VARCHAR(256) NOT NULL,
	[nationality] VARCHAR(256) NOT NULL,
	[length] VARCHAR(30) NOT NULL, 
	[recordLap] VARCHAR(30) NOT NULL
);

SET IDENTITY_INSERT [dbo].[Circuits] ON;

INSERT INTO [dbo].[Circuits]
(
	id,
	name,
	nationality,
	length,
	recordLap
)
VALUES
(1,'Autodromo Nazionale di Monza','Italy','5793','1:21.046'),
(2,'Albert Park Circuit','Australia','5303','1:24.125'),
(3,'Autodromo Hermanos Rodriguez','Mexico','4304','1:18.741'),
(4,'Detroit street circuit','USA','4168','1:40.464'),
(5,'Pescara Circuit','Italy','25800','9:44.6');