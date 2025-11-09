CREATE PROCEDURE [dbo].[spTravelPlan_GetAll]
AS
BEGIN
	SELECT Id,Title, NumberOfPeople, Destination, Description, StartDate, EndDate, Budget
	FROM [dbo].[TravelPlan]
	WHERE IsActive = 1;
END
