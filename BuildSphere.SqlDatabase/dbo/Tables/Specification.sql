CREATE TABLE [dbo].[Specification] (
    [Id]             INT            NOT NULL,
    [Name]           VARCHAR (1000) NOT NULL,
    [MeterialType]   VARCHAR (50)   NULL,
    [Quantity]       INT            NULL,
    [AdditionalInfo] VARCHAR (1000) NULL,
    CONSTRAINT [PK_Specification] PRIMARY KEY CLUSTERED ([Id] ASC)
);

