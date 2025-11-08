CREATE PROCEDURE [dbo].[spUser_Edit]
	@Id INT,
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Email NVARCHAR(255),
	@PhoneNumber NVARCHAR(15) = NULL,
	@Second_PhoneNumber NVARCHAR(15) = NULL,
	@Third_PhoneNumber NVARCHAR(15) = NULL,
	@IdCard_Number NVARCHAR(50) = '',
	@Passport_Number NVARCHAR(50) = ''
AS
BEGIN
	UPDATE [dbo].[Users]
	SET
		FirstName = @FirstName,
		LastName = @LastName,
		Email = @Email,
		PhoneNumber = @PhoneNumber,
		Second_PhoneNumber = @Second_PhoneNumber,
		Third_PhoneNumber = @Third_PhoneNumber,
		IdCard_Number = @IdCard_Number,
		Passport_Number = @Passport_Number
	WHERE Id = @Id;
END
