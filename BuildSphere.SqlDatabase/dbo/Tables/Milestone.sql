CREATE TABLE [dbo].[Milestone] (
    [Id]            INT            NOT NULL,
    [ProjectId]     INT            NOT NULL,
    [Name]          VARCHAR (50)   NOT NULL,
    [PaymentAmount] DECIMAL (9, 2) NULL,
    [PaidDate]      DATETIME       NULL,
    CONSTRAINT [PK_Milestone] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Milestone_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id])
);

