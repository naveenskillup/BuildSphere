-- =============================================
-- Author:		Naveen Kumar
-- Create date: August 17, 2025
-- Description:	
-- =============================================
CREATE PROCEDURE sp_GetUsers
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
  FROM [BuildSphereDB].[dbo].[User]

END