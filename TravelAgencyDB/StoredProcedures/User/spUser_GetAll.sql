CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
BEGIN
	SELECT Id, FirstName, LastName, Email, Password, PhoneNumber, Second_PhoneNumber, Third_PhoneNumber, IdCard_Number, 
	Passport_Number,CreationDate,Passport_ImgUrl,IdCard_ImgUrl
	FROM [dbo].[Users]
	WHERE IsActive =1;
END
