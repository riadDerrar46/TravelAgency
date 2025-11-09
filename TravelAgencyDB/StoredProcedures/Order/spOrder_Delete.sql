CREATE PROCEDURE [dbo].[spOrder_Delete]
@Id INT
AS
BEGIN
 UPDATE [dbo].[Orders]
 set IsActive = 0,
	 DeleteDate = GETDATE()
 WHERE Id = @Id;
END

