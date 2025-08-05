CREATE TABLE [dbo].[Milestone] (
    [Id]            INT            NOT NULL,
    [ProjectId]     INT            NOT NULL,
    [Name]          VARCHAR (50)   NOT NULL,
    [PaymentAmount] DECIMAL (9, 2) NULL,
    [PaidDate]      DATETIME       NULL
);

