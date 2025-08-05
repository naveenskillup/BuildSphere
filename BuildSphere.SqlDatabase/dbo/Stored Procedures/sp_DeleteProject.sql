-- =============================================
-- Author:		Naveen Kumar
-- Create date: August 05, 2025
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteProject]
	@Id INT
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [BuildSphereDB].[dbo].[Project]
	WHERE Id = @Id

END