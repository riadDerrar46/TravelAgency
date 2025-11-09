CREATE PROCEDURE [dbo].[spTravelPlan_Search]
    @Title NVARCHAR(200) = NULL,
    @NumberOfPeople INT = NULL,
    @Destination NVARCHAR(200) = NULL,
    @Description NVARCHAR(MAX) = NULL,
    @StartDate DATETIME = NULL,
    @EndDate DATETIME = NULL,
    @Budget DECIMAL(18,2) = NULL
AS
BEGIN
    SELECT *
    FROM [dbo].[TravelPlan]
    WHERE (IsActive = 1)
      AND (@Title IS NULL OR Title LIKE '%' + @Title + '%')
      AND (@NumberOfPeople IS NULL OR NumberOfPeople = @NumberOfPeople)
      AND (@Destination IS NULL OR Destination LIKE '%' + @Destination + '%')
      AND (@Description IS NULL OR Description LIKE '%' + @Description + '%')
      AND (@StartDate IS NULL OR StartDate >= @StartDate)
      AND (@EndDate IS NULL OR EndDate <= @EndDate)
      AND (@Budget IS NULL OR Budget <= @Budget)
END
