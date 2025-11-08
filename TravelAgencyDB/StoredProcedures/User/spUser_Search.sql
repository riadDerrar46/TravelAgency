CREATE PROCEDURE [dbo].[spUser_Search]
	@FirstName NVARCHAR(100) = NULL,
	@LastName NVARCHAR(100) = NULL,
	@Email NVARCHAR(255) = NULL,
	@Password nvarchar(30) = NULL,
	@PhoneNumber NVARCHAR(15) = NULL,
	@IdCard_Number NVARCHAR(50) = NULL,
	@Passport_Number NVARCHAR(50) = NULL
AS
BEGIN
	SELECT *
	FROM [dbo].[Users]
	WHERE (IsActive = 1)
	 AND (@FirstName IS NULL OR FirstName LIKE '%' + @FirstName + '%')
	 AND (@LastName IS NULL OR LastName LIKE '%' + @LastName + '%')
	 AND (@Password IS NULL OR Password LIKE  '%' + @Password + '%')
	 AND (@Email IS NULL OR Email LIKE '%' + @Email + '%')
	 AND (@PhoneNumber IS NULL OR PhoneNumber LIKE '%' + @PhoneNumber + '%')
	 AND (@PhoneNumber IS NULL OR Second_PhoneNumber LIKE '%' + @PhoneNumber + '%')
	 AND (@PhoneNumber IS NULL OR Third_PhoneNumber LIKE '%' + @PhoneNumber + '%')
	 AND (@IdCard_Number IS NULL OR IdCard_Number LIKE '%' + @IdCard_Number + '%')
	 AND (@Passport_Number IS NULL OR Passport_Number LIKE '%' + @Passport_Number + '%')
	 
END
