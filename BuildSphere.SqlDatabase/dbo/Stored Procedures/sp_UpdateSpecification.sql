-- =============================================
-- Author:        Naveen Kumar
-- Create date:   August 05, 2025
-- Description:   Update an existing specification
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateSpecification]
    @Id INT,
	@ProjectId INT,
    @Name VARCHAR(1000),
    @MeterialType VARCHAR(50) = NULL,
    @Quantity INT = NULL,
    @AdditionalInfo VARCHAR(1000) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Specification
    SET ProjectId = @ProjectId,
		Name = @Name,
        MeterialType = @MeterialType,
        Quantity = @Quantity,
        AdditionalInfo = @AdditionalInfo
    WHERE Id = @Id;

END