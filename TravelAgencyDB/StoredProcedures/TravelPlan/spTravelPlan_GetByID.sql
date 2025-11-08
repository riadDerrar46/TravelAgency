CREATE PROCEDURE [dbo].[spTravelPlan_GetByID]
	@Id INT
AS
BEGIN
	SELECT Id, NumberOfPeople, Destination, Description, StartDate, EndDate, Budget
	FROM [dbo].[TravelPlans]
	WHERE Id = @Id AND IsActive =1;
END
