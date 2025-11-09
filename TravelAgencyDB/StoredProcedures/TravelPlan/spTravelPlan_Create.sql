CREATE PROCEDURE [dbo].[spTravelPlan_Create]
	@Title nvarchar(120) ,
	@NumberOfPeople INT =1,
	@Destination NVARCHAR(255),
	@Description NVARCHAR(400),
	@StartDate DATETIME,
	@EndDate DATETIME,
	@Budget DECIMAL(18,2),
	@IsActive bit = 1,
	@CreationDate datetime,
	@DeleteDate datetime
AS
BEGIN
	INSERT INTO [dbo].[TravelPlan] (
		Title ,NumberOfPeople, Destination, Description, StartDate, EndDate, Budget, IsActive, CreationDate, DeleteDate
	)
	VALUES (
		@Title,@NumberOfPeople, @Destination, @Description, @StartDate, @EndDate, @Budget,@IsActive, @CreationDate, NULL
	);
END
