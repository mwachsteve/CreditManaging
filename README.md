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


##Back end asp.net web api While testing with postman disable ssl

1.GET/ customer

POST/ RegisterCustomer request body { "Id": 2, "Name": "test1", "CreditLimit": "high", "PaymentTerms": "chq" }

GET /CustomerAccounts/id

GET /SaleInvoices/Id

POST /Sale request body { "Id": 2, "product": "test", "amount": "299", "transactionDate": "2022-03-02T00:00:00", "price": "199", "unit": "1", "paymentTerms": "30", "paymentMode": "chq", "dueDate": "2022-04-11T00:00:00", "customerId": 1 }

POST /MakePayment request body { "Id": 10, "InvoiceId": 1, "Amount": "100", "PayDate": "2021-11-11T00:00:00", "DueDate": "2021-11-11T00:00:00", "SaleInvoice": [ { "Id": 1, "ActualBalance": "1000", "AvailableBalance": "99", "CreditLimit": "2000" } ] }

GET / Payments/{customerid}

POST /Reverse Sale { "Id": 2, "product": "test", "amount": "299", "transactionDate": "2022-03-02T00:00:00", "price": "199", "unit": "1", "paymentTerms": "30", "paymentMode": "chq", "dueDate": "2022-04-11T00:00:00", "customerId": 1, "rejectStatus" : 1, "paidStatus" : 0 }

GET /UnPaidInvoices/id
