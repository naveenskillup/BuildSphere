-- =============================================
-- Author:		Naveen Kumar
-- Create date: August 05, 2025
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteMilestone]
	@Id INT
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [BuildSphereDB].[dbo].[Milestone]
	WHERE Id = @Id

END