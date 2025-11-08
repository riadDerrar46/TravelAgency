CREATE PROCEDURE [dbo].[spClient_Search]
	@FirstName NVARCHAR(100) = NULL,
	@LastName NVARCHAR(100) = NULL,
	@Email NVARCHAR(255) = NULL,
	@PhoneNumber NVARCHAR(15) = NULL,
	@Job NVARCHAR(100) = NULL,
	@IdCard_Number NVARCHAR(50) = NULL,
	@Passport_Number NVARCHAR(50) = NULL
AS
BEGIN
	SELECT *
	FROM [dbo].[Clients]
	WHERE (IsActive = 1 )
	 AND (@FirstName IS NULL OR FirstName LIKE '%' + @FirstName + '%')
	 AND (@LastName IS NULL OR LastName LIKE '%' + @LastName + '%')
	 AND (@Email IS NULL OR Email LIKE '%' + @Email + '%')
	 AND (@PhoneNumber IS NULL OR PhoneNumber LIKE '%' + @PhoneNumber + '%')
	 AND (@PhoneNumber IS NULL OR Second_PhoneNumber LIKE '%' + @PhoneNumber + '%')
	 AND (@PhoneNumber IS NULL OR Third_PhoneNumber LIKE '%' + @PhoneNumber + '%')
	 AND (@Job IS NULL OR Job LIKE '%' + @Job + '%')
	 AND (@IdCard_Number IS NULL OR IdCard_Number LIKE '%' + @IdCard_Number + '%')
	 AND (@Passport_Number IS NULL OR Passport_Number LIKE '%' + @Passport_Number + '%');
END
