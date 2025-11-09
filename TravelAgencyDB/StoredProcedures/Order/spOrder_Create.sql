CREATE PROCEDURE [dbo].[spOrder_Create]
	@OrderDate DATETIME,
	@TotalAmount DECIMAL(18,2),
	@Status INT =1,
	@Status_Reason NVARCHAR(100) = '',
	@TravelPlan_Id INT,
	@ClientId INT,
	@IsActive bit = 1,
	@CreationDate datetime,
	@DeleteDate datetime
AS
BEGIN
	INSERT INTO [dbo].[Orders] (
		OrderDate, TotalAmount, Status, Status_Reason, TravelPlan_Id, ClientId, IsActive, CreationDate, DeleteDate
	)
	VALUES (
		@OrderDate, @TotalAmount, @Status, @Status_Reason, @TravelPlan_Id, @ClientId,@IsActive,@CreationDate, @DeleteDate
	);
END
