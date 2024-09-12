CREATE PROCEDURE [dbo].[SP_User_Insert]
	@email VARCHAR(320),
	@password NVARCHAR(64)
AS
BEGIN
	DECLARE @salt UNIQUEIDENTIFIER = NEWID()
	INSERT INTO [User]([Email], [Password], [Salt])
		OUTPUT [inserted].[UserId]
		VALUES (@email, [dbo].[SF_HashAndSaltPassword](@password, @salt), @salt)
END
