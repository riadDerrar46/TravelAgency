CREATE PROCEDURE [dbo].[spUser_Delete]
@Id INT
AS
BEGIN
 UPDATE [dbo].[Users]
 set IsActive = 0,
	 DeleteDate = GETDATE()
 WHERE Id = @Id;
END
RETURN 0
