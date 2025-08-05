-- =============================================
-- Author:        Naveen Kumar
-- Create date:   August 05, 2025
-- Description:   Inserts a new milestone for a project
-- =============================================
CREATE PROCEDURE sp_CreateMilestone
    @ProjectId INT,
    @Name VARCHAR(50),
    @PaymentAmount DECIMAL(9, 2) = NULL,
    @PaidDate DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Milestone(ProjectId, Name, PaymentAmount, PaidDate)
    VALUES (@ProjectId, @Name, @PaymentAmount, @PaidDate);

    SELECT @@IDENTITY AS Id;
END