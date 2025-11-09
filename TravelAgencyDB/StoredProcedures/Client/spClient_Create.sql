CREATE PROCEDURE [dbo].[spClient_Create]
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Email NVARCHAR(100),
	@PhoneNumber NVARCHAR(15) = NULL,
	@Job nvarchar(100) = NULL,
	@Second_PhoneNumber NVARCHAR(15) = NULL,
	@Third_PhoneNumber NVARCHAR(15) = NULL,
	@IdCard_Number NVARCHAR(50) = '',
	@Passport_Number NVARCHAR(50) = '',
	@Passport_ImgUrl nvarchar(255) = null,
	@IdCard_ImgUrl nvarchar(255) = null,
	@IsActive bit = 1,
	@CreationDate datetime,
	@DeleteDate datetime
AS
BEGIN
	INSERT INTO [dbo].[Clients] (
		FirstName, LastName, Email,Job, PhoneNumber, Second_PhoneNumber, Third_PhoneNumber, IdCard_Number,
		Passport_Number, IsActive, CreationDate, DeleteDate,Passport_ImgUrl,IdCard_ImgUrl
	)
	VALUES (
		@FirstName, @LastName, @Email,@Job, @PhoneNumber, @Second_PhoneNumber, @Third_PhoneNumber, @IdCard_Number,
		@Passport_Number,@IsActive, @CreationDate, Null,@Passport_ImgUrl,@IdCard_ImgUrl
	);
end