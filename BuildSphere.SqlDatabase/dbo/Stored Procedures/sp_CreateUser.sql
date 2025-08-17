CREATE PROCEDURE [dbo].[sp_CreateUser]
    @FullName NVARCHAR(100),
    @Email NVARCHAR(150),
    @Village NVARCHAR(100),
    @PhoneNumber NVARCHAR(20),
    @Role NVARCHAR(50),
    @Password NVARCHAR(255)   -- should be hashed before passing
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[User] (FullName, Email, Village, PhoneNumber, Role, Password)
    VALUES (@FullName, @Email, @Village, @PhoneNumber, @Role, @Password);

    SELECT SCOPE_IDENTITY() AS Id;
END