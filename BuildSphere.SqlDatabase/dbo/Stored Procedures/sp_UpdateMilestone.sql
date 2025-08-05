-- =============================================
-- Author:		Naveen Kumar
-- Create date: August 05, 2025
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateMilestone]
	@Id INT,
	@ProjectId INT,
    @Name VARCHAR(50),
    @PaymentAmount DECIMAL(9, 2) = NULL,
    @PaidDate DATETIME = NULL
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE dbo.Milestone SET
		[ProjectId] = @ProjectId
		, [Name] = @Name
		, [PaymentAmount] = @PaymentAmount
		, [PaidDate] = @PaidDate
		WHERE Id = @Id

END