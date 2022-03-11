# CreditManaging
Back end asp.net web api

## Create Database student 
## run the queries to create tables


CREATE TABLE [dbo].[Accounts] (
    [Id]               INT            NOT NULL,
    [AccountNumber]    NVARCHAR (50)  NULL,
    [ActualBalance]    NVARCHAR (MAX) NULL,
    [AvailableBalance] NVARCHAR (MAX) NULL,
    [CreditLimit]      NVARCHAR (50)  NULL,
    [CustomerId]       INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Customer] (
    [Id]           INT           NOT NULL,
    [Name]         NVARCHAR (50) NULL,
    [CreditLimit]  NVARCHAR (50) NULL,
    [PaymentTerms] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Payments] (
    [Id]         INT           NOT NULL,
    [InvoiceId]  INT           NULL,
    [Amount]     NVARCHAR (50) NULL,
    [PayDate]    DATETIME      NULL,
    [DueDate]    DATETIME      NULL,
    [CustomerId] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Sales] (
    [Id]              INT           NOT NULL,
    [product]         NVARCHAR (50) NULL,
    [amount]          NVARCHAR (50) NULL,
    [transactionDate] DATETIME      NULL,
    [price]           NVARCHAR (50) NULL,
    [unit]            NVARCHAR (50) NULL,
    [paymentTerms]    NVARCHAR (50) NULL,
    [paymentMode]     NVARCHAR (50) NULL,
    [dueDate]         DATETIME      NULL,
    [customerId]      INT           NULL,
    [rejectStatus]    INT           DEFAULT ((0)) NOT NULL,
    [paidStatus]      INT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

