CREATE PROCEDURE [dbo].[spTravelPlan_GetByID]
	@Id INT
AS
BEGIN
	SELECT Id,Title, NumberOfPeople, Destination, Description, StartDate, EndDate, Budget
	FROM [dbo].[TravelPlans]
	WHERE Id = @Id AND IsActive =1;
END
