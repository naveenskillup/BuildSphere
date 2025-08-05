-- =============================================
-- Author:		Naveen Kumar
-- Create date: August 05, 2025
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_CreateProject]
	@BuilderId INT,
    @HomeownerId INT,
    @Name NVARCHAR(255),
    @StartDate DATETIME,
    @ExpectedCloseDate DATETIME = NULL,
    @AdvanceAmount DECIMAL(18, 2)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO dbo.Project(BuilderId, HomeownerId, Name, StartDate, ExpectedCloseDate, AdvanceAmount) 
	VALUES (@BuilderId, @HomeownerId, @Name, @StartDate, @ExpectedCloseDate, @AdvanceAmount);

	SELECT @@IDENTITY AS Id
END