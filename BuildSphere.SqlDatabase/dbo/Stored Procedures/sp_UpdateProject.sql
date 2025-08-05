-- =============================================
-- Author:		Naveen Kumar
-- Create date: August 05, 2025
-- Description:	
-- =============================================
CREATE PROCEDURE sp_UpdateProject
	@Id INT,
	@BuilderId INT,
    @HomeownerId INT,
    @Name NVARCHAR(255),
    @StartDate DATETIME,
    @ExpectedCloseDate DATETIME = NULL,
    @AdvanceAmount DECIMAL(18, 2)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE dbo.Project SET
		[BuilderId] = @BuilderId
		, [HomeownerId] = @HomeownerId
		, [Name] = @Name
		, [StartDate] = @StartDate
		, [ExpectedCloseDate] = @ExpectedCloseDate
		, [AdvanceAmount] = @AdvanceAmount
		WHERE Id = @Id

END