﻿CREATE TABLE [dbo].[Projects]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Name VARCHAR(100) NOT NULL,
	IdUser INT NOT NULL,
	CreationDate DATETIME NOT NULL DEFAULT GETDATE()

	FOREIGN KEY(IdUser) REFERENCES [Users](Id)
)
