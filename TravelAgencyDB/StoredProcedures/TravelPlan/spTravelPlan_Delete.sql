CREATE PROCEDURE [dbo].[spTravelPlan_Delete]
@Id INT
AS
BEGIN
 UPDATE [dbo].[TravelPlan]
 set IsActive = 0,
	 DeleteDate = GETDATE()
 WHERE Id = @Id;
END
RETURN 0
