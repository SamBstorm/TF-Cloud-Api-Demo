CREATE PROCEDURE [dbo].[SP_User_CheckEmailAndPassword]
	@email VARCHAR(320),
	@password NVARCHAR(64)
AS
BEGIN
	SELECT [UserId]
		FROM [User]
		WHERE	[Email] = @email
			AND [Password] = [dbo].[SF_HashAndSaltPassword](@password, [Salt])
			AND ([DisabledAt] IS NULL
				OR GETDATE() < DATEADD(DAY,30,[DisabledAt]))
END
