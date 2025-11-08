CREATE PROCEDURE [dbo].[spUser_GetByID]
	@Id INT
AS
BEGIN
	SELECT Id, FirstName, LastName, Email,Password, PhoneNumber, Second_PhoneNumber, Third_PhoneNumber, IdCard_Number, 
	Passport_Number,CreationDate,Passport_ImgUrl,IdCard_ImgUrl
	FROM [dbo].[Users]
	WHERE Id = @Id AND IsActive =1;
END
