CREATE PROCEDURE [dbo].[spClient_GetAll]
AS
BEGIN
	SELECT Id, FirstName, LastName, Email, PhoneNumber, Second_PhoneNumber, Third_PhoneNumber, Job, IdCard_Number,
	IdCard_ImgUrl, Passport_Number, Passport_ImgUrl
	FROM [dbo].[Clients]
	WHERE IsActive = 1;
END
