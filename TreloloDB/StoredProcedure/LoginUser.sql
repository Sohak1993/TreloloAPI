﻿CREATE PROCEDURE [dbo].[Login]
	@email VARCHAR(100),
	@password VARCHAR(50)
AS
BEGIN
	DECLARE @salt VARCHAR(100)
	SELECT @salt = Salt FROM [Users] WHERE Email = @email

	DECLARE @hash VARBINARY(64)
	SET @hash = HASHBYTES('SHA2_512', CONCAT(@salt, @password, @salt))

	SELECT Id, Email
	FROM [Users]
	WHERE Password = @hash AND Email = @email
END
