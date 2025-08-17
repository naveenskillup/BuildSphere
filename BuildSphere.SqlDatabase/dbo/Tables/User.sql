CREATE TABLE [dbo].[User] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [FullName]    VARCHAR (250) NULL,
    [Email]       VARCHAR (250) NOT NULL,
    [Village]     VARCHAR (250) NULL,
    [PhoneNumber] VARCHAR (250) NULL,
    [Role]        VARCHAR (250) NOT NULL,
    [Password]    VARCHAR (250) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

