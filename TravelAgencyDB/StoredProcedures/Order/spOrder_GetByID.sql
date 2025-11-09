CREATE PROCEDURE [dbo].[spOrder_GetByID]
	@Id INT
AS
BEGIN
	SELECT Id, OrderDate, TotalAmount, Status, Status_Reason, TravelPlan_Id, ClientId,CreationDate
	FROM [dbo].[Orders]
	WHERE Id = @Id AND IsActive =1;
END
