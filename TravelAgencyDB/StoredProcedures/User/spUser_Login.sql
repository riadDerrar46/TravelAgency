CREATE PROCEDURE [dbo].[spUser_Login]
	@Email NVARCHAR(100),
	@Password NVARCHAR(30)
AS
BEGIN
	SELECT Id, FirstName, LastName, Email, PhoneNumber, Second_PhoneNumber, Third_PhoneNumber, IdCard_Number, Passport_Number
	FROM [dbo].[Users]
	WHERE Email = @Email AND Password = @Password AND IsActive = 1;
END
