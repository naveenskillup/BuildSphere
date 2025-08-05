-- =============================================
-- Author:		Naveen Kumar
-- Create date: August 05, 2025
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetProjectById]
	@Id INT
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
  WHERE Id = @Id

END