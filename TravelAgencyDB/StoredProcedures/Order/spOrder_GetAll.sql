CREATE PROCEDURE [dbo].[spOrder_GetAll]
AS
BEGIN
	SELECT Id, OrderDate, TotalAmount, Status, Status_Reason, TravelPlan_Id, ClientId, IsActive, CreationDate, DeleteDate
	FROM [dbo].[Orders]
	WHERE IsActive =1;
END
