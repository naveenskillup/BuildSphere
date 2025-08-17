-- =============================================
-- Author:		Naveen Kumar
-- Create date: August 17, 2025
-- Description:	
-- =============================================
CREATE PROCEDURE Sp_GetUserByUserNameAndPassword
	@UserName varchar(255),
	@Password varchar(255)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT [Id]
      ,[FullName]
      ,[Email]
      ,[Village]
      ,[PhoneNumber]
      ,[Role]
      ,[Password]
  FROM [BuildSphereDB].[dbo].[User] WHERE Email = @UserName AND [Password] = @Password;

END