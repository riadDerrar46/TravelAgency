CREATE PROCEDURE [dbo].[spClient_Edit]
	@Id INT,
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Email NVARCHAR(255),
	@PhoneNumber NVARCHAR(15) = NULL,
	@Second_PhoneNumber NVARCHAR(15) = NULL,
	@Third_PhoneNumber NVARCHAR(15) = NULL,
	@Job NVARCHAR(100) = 'None',
	@IdCard_Number NVARCHAR(50) = '',
	@IdCard_ImgUrl NVARCHAR(255) = NULL,
	@Passport_Number NVARCHAR(50) = '',
	@Passport_ImgUrl NVARCHAR(255) = NULL
AS
BEGIN
	UPDATE [dbo].[Clients]
	SET
		FirstName = @FirstName,
		LastName = @LastName,
		Email = @Email,
		PhoneNumber = @PhoneNumber,
		Second_PhoneNumber = @Second_PhoneNumber,
		Third_PhoneNumber = @Third_PhoneNumber,
		Job = @Job,
		IdCard_Number = @IdCard_Number,
		IdCard_ImgUrl = @IdCard_ImgUrl,
		Passport_Number = @Passport_Number,
		Passport_ImgUrl = @Passport_ImgUrl
	WHERE Id = @Id;
END
