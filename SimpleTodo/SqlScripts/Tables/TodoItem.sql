﻿CREATE TABLE [dbo].[TodoItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[Completed] BIT NOT NULL,
	[Description] NVARCHAR(MAX)
)