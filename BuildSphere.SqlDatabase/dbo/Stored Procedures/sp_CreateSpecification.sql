-- =============================================
-- Author:        Naveen Kumar
-- Create date:   August 05, 2025
-- Description:   Insert a new specification
-- =============================================
CREATE PROCEDURE [dbo].[sp_CreateSpecification]
	@ProjectId INT,
    @Name VARCHAR(1000),
    @MeterialType VARCHAR(50) = NULL,
    @Quantity INT = NULL,
    @AdditionalInfo VARCHAR(1000) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Specification(ProjectId, Name, MeterialType, Quantity, AdditionalInfo)
    VALUES (@ProjectId, @Name, @MeterialType, @Quantity, @AdditionalInfo);

    SELECT SCOPE_IDENTITY() AS Id;
END