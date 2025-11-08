CREATE PROCEDURE [dbo].[spOrder_Search]
	@ClientId INT
AS
BEGIN
	SELECT Id, OrderDate, TotalAmount, Status, Status_Reason, TravelPlan_Id, ClientId
	FROM [dbo].[Orders]
	WHERE IsActive = 1 AND ClientId = @ClientId;
END
