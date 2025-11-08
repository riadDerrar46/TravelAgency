CREATE PROCEDURE [dbo].[spClient_GetByID]
	@Id INT
AS
BEGIN
	SELECT Id, FirstName, LastName, Email, PhoneNumber, Second_PhoneNumber, Third_PhoneNumber, Job, IdCard_Number, IdCard_ImgUrl, Passport_Number, Passport_ImgUrl
	FROM [dbo].[Clients]
	WHERE Id = @Id AND IsActive =1;
END
