CREATE PROCEDURE [dbo].[spClient_GetByID]
	@Id INT
AS
BEGIN
		SELECT Id, FirstName, LastName, Email,Job, PhoneNumber, Second_PhoneNumber, Third_PhoneNumber, IdCard_Number, 
	Passport_Number,CreationDate,Passport_ImgUrl,IdCard_ImgUrl
	FROM [dbo].[Clients]
	WHERE Id = @Id AND IsActive =1;
END
