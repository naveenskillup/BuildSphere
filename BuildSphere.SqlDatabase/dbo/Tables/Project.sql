CREATE TABLE [dbo].[Project] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [BuilderId]         INT            NOT NULL,
    [HomeownerId]       INT            NOT NULL,
    [Name]              NVARCHAR (50)  NULL,
    [StartDate]         DATETIME       NOT NULL,
    [ExpectedCloseDate] DATETIME       NULL,
    [AdvanceAmount]     DECIMAL (9, 2) NULL,
    CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED ([Id] ASC)
);

