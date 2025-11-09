CREATE PROCEDURE [dbo].[spClient_GetAll]
AS
BEGIN
		SELECT Id, FirstName, LastName, Email,Job, PhoneNumber, Second_PhoneNumber, Third_PhoneNumber, IdCard_Number, 
	Passport_Number,CreationDate,Passport_ImgUrl,IdCard_ImgUrl
	FROM [dbo].[Clients]
	WHERE IsActive = 1;
END
