CREATE PROCEDURE [dbo].[sp_UpdateUser]
    @Id INT,
    @FullName NVARCHAR(100),
    @Email NVARCHAR(150),
    @Village NVARCHAR(100),
    @PhoneNumber NVARCHAR(20),
    @Role NVARCHAR(50),
    @Password NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[User]
    SET [FullName] = @FullName,
        [Email] = @Email,
        [Village] = @Village,
        [PhoneNumber] = @PhoneNumber,
        [Role] = @Role,
        [Password] = @Password
    WHERE [Id] = @Id;
END