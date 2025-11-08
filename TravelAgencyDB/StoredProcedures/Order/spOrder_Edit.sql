CREATE PROCEDURE [dbo].[spOrder_Edit]
	@Id INT,
	@OrderDate DATETIME,
	@TotalAmount DECIMAL(18,2),
	@Status INT,
	@Status_Reason NVARCHAR(100),
	@TravelPlan_Id INT,
	@ClientId INT
AS
BEGIN
	UPDATE [dbo].[Orders]
	SET
		OrderDate = @OrderDate,
		TotalAmount = @TotalAmount,
		Status = @Status,
		Status_Reason = @Status_Reason,
		TravelPlan_Id = @TravelPlan_Id,
		ClientId = @ClientId
	WHERE Id = @Id;
END
