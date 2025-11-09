CREATE PROCEDURE [dbo].[spTravelPlan_Delete]
@Id INT
AS
BEGIN
 UPDATE [dbo].[TravelPlans]
 set IsActive = 0,
	 DeleteDate = GETDATE()
 WHERE Id = @Id;
END
RETURN 0
