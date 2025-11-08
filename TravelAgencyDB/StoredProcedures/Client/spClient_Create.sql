CREATE PROCEDURE [dbo].[spClient_Create]
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
	INSERT INTO [dbo].[Clients] (
		FirstName, LastName, Email, PhoneNumber, Second_PhoneNumber, Third_PhoneNumber, Job, IdCard_Number, IdCard_ImgUrl, Passport_Number, Passport_ImgUrl, IsActive, CreationDate, DeleteDate
	)
	VALUES (
		@FirstName, @LastName, @Email, @PhoneNumber, @Second_PhoneNumber, @Third_PhoneNumber, @Job, @IdCard_Number, @IdCard_ImgUrl, @Passport_Number, @Passport_ImgUrl,1, GETDATE(), NULL
	);
END
