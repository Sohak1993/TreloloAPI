CREATE PROCEDURE [dbo].[RegisterUser]
	@email VARCHAR(100),
	@password VARCHAR(100)
AS
BEGIN
	DECLARE @salt VARCHAR(100)
	SET @salt = CONCAT(NEWID(), NEWID(), NEWID())

	DECLARE @hash VARBINARY(64)
	SET @hash = HASHBYTES('SHA2_512', CONCAT(@salt, @password, @salt))

	INSERT INTO [Users] (Email, Password, Salt) VALUES (@email, @hash, @salt)
END
