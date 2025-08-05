-- =============================================
-- Author:		Naveen Kumar
-- Create date: August 05, 2025
-- Description:	
-- =============================================
CREATE PROCEDURE sp_GetProjects
AS
BEGIN

	SET NOCOUNT ON;

	SELECT [Id]
      ,[BuilderId]
      ,[HomeownerId]
      ,[Name]
      ,[StartDate]
      ,[ExpectedCloseDate]
      ,[AdvanceAmount]
  FROM [BuildSphereDB].[dbo].[Project]

END
