CREATE PROCEDURE [dbo].[SP_User_ChangePassword]
	@id UNIQUEIDENTIFIER,
	@password NVARCHAR(64)
AS
BEGIN
	DECLARE @salt UNIQUEIDENTIFIER = NEWID()
	UPDATE [User]
		SET [Password] = [dbo].[SF_HashAndSaltPassword](@password, @salt),
			[Salt] = @salt
		WHERE [UserId] = @id
END
