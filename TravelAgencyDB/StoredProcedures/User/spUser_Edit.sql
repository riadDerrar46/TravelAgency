CREATE PROCEDURE [dbo].[spUser_Edit]
	@Id INT,
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Email NVARCHAR(255),
	@PhoneNumber NVARCHAR(15) = NULL,
	@Password NVARCHAR(30),
	@Second_PhoneNumber NVARCHAR(15) = NULL,
	@Third_PhoneNumber NVARCHAR(15) = NULL,
	@IdCard_Number NVARCHAR(50) = '',
	@Passport_Number NVARCHAR(50) = '',
	@Passport_ImgUrl nvarchar(255) = null,
	@IdCard_ImgUrl nvarchar(255) = null
	,@IsActive bit = 1,
	@CreationDate datetime,
	@DeleteDate datetime
AS
BEGIN
	UPDATE [dbo].[Users]
	SET
		FirstName = @FirstName,
		LastName = @LastName,
		Email = @Email,
		Password = @Password,  -- Retain existing password
		PhoneNumber = @PhoneNumber,
		Second_PhoneNumber = @Second_PhoneNumber,
		Third_PhoneNumber = @Third_PhoneNumber,
		IdCard_Number = @IdCard_Number,
		Passport_Number = @Passport_Number
		,Passport_ImgUrl = @Passport_ImgUrl,
		IdCard_ImgUrl = @IdCard_ImgUrl,
		IsActive = @IsActive,
		CreationDate = @CreationDate,
		DeleteDate = @DeleteDate

	WHERE Id = @Id;
END
