CREATE PROCEDURE [dbo].[spTravelPlan_Create]
	@NumberOfPeople INT =1,
	@Destination NVARCHAR(255),
	@Description NVARCHAR(400),
	@StartDate DATETIME,
	@EndDate DATETIME,
	@Budget DECIMAL(18,2)
AS
BEGIN
	INSERT INTO [dbo].[TravelPlans] (
		NumberOfPeople, Destination, Description, StartDate, EndDate, Budget, IsActive, CreationDate, DeleteDate
	)
	VALUES (
		@NumberOfPeople, @Destination, @Description, @StartDate, @EndDate, @Budget,1, GETDATE(), NULL
	);
END
