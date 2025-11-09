CREATE PROCEDURE [dbo].[spTravelPlan_Edit]
	@Id INT,
	@Title nvarchar(120),
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
	UPDATE [dbo].[TravelPlan]
	SET
		Title = @Title ,
		NumberOfPeople = @NumberOfPeople,
		Destination = @Destination,
		Description = @Description,
		StartDate = @StartDate,
		EndDate = @EndDate,
		Budget = @Budget,
		IsActive = @IsActive ,
	    CreationDate = @CreationDate ,
	     DeleteDate = @DeleteDate
	WHERE Id = @Id;
END
