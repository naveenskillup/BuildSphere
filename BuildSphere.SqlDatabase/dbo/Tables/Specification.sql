CREATE TABLE [dbo].[Specification] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [ProjectId]      INT            NOT NULL,
    [Name]           VARCHAR (1000) NOT NULL,
    [MeterialType]   VARCHAR (50)   NULL,
    [Quantity]       INT            NULL,
    [AdditionalInfo] VARCHAR (1000) NULL,
    CONSTRAINT [PK_Specification] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Specification_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id])
);

