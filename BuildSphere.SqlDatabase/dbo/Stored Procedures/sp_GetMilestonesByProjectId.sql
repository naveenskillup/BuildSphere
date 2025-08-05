-- =============================================
-- Author:        Naveen Kumar
-- Create date:   August 05, 2025
-- Description:   Get all milestones
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetMilestonesByProjectId]
	@ProjectId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT [Id],
           [ProjectId],
           [Name],
           [PaymentAmount],
           [PaidDate]
    FROM [BuildSphereDB].[dbo].[Milestone]
	WHERE ProjectId = @ProjectId;

END