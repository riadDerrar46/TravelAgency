CREATE PROCEDURE [dbo].[spClient_Delete]
@Id INT
AS
BEGIN
 UPDATE [dbo].[Clients]
 set IsActive = 0,
	 DeleteDate = GETDATE()
 WHERE Id = @Id;
END

