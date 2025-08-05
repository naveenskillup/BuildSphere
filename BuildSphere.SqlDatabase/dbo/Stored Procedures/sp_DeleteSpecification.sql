-- =============================================
-- Author:        Naveen Kumar
-- Create date:   August 05, 2025
-- Description:   Delete a specification by ID
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteSpecification]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [BuildSphereDB].[dbo].[Specification]
    WHERE Id = @Id;
END