CREATE PROCEDURE [dbo].[spTravelPlan_Edit]
	@Id INT,
	@NumberOfPeople INT =1,
	@Destination NVARCHAR(255),
	@Description NVARCHAR(400),
	@StartDate DATETIME,
	@EndDate DATETIME,
	@Budget DECIMAL(18,2)
AS
BEGIN
	UPDATE [dbo].[TravelPlans]
	SET
		NumberOfPeople = @NumberOfPeople,
		Destination = @Destination,
		Description = @Description,
		StartDate = @StartDate,
		EndDate = @EndDate,
		Budget = @Budget
	WHERE Id = @Id;
END
