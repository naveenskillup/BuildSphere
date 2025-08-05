-- =============================================
-- Author:        Naveen Kumar
-- Create date:   August 05, 2025
-- Description:   Get all specifications
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSpecificationsByProjectId]
	@ProjectId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT [Id],
		   [ProjectId],
           [Name],
           [MeterialType],
           [Quantity],
           [AdditionalInfo]
    FROM [BuildSphereDB].[dbo].[Specification]
	WHERE ProjectId = @ProjectId;
END