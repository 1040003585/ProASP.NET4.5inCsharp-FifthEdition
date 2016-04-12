
create database SportsStore3
go
use SportsStore3

CREATE TABLE [dbo].[Products] (
    [ProductID]   INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100)  NOT NULL,
    [Description] NVARCHAR (500)  NULL,
    [Category]    NVARCHAR (50)   NOT NULL,
    [Price]       DECIMAL (16, 2) NOT NULL,
    [Store]       INT 		  NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC)
);


CREATE TABLE [dbo].[Orders] (
    [OrderId]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [Phone]      NVARCHAR (MAX) NULL,
    [Email]      NVARCHAR (MAX) NULL,
    [Comments]      NVARCHAR (MAX) NULL,
    [AddrInfo]      NVARCHAR (MAX) NULL,
    [City]       NVARCHAR (MAX) NULL,
    [State]      NVARCHAR (MAX) NULL,
    [GiftWrap]   BIT            NOT NULL,
    [Dispatched] BIT            NOT NULL,
    CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED ([OrderId] ASC)
);

CREATE TABLE [dbo].[OrderLines] (
    [OrderLineId]       INT IDENTITY (1, 1) NOT NULL,
    [Quantity]          INT NOT NULL,
    [Product_ProductID] INT NULL,
    [Order_OrderId]     INT NULL,
    CONSTRAINT [PK_dbo.OrderLines] PRIMARY KEY CLUSTERED ([OrderLineId] ASC),

    CONSTRAINT [FK_dbo.OrderLines_dbo.Products_Product_ProductID] FOREIGN KEY 
        ([Product_ProductID]) REFERENCES [dbo].[Products] ([ProductID])
		ON  DELETE CASCADE   ON UPDATE CASCADE,
    CONSTRAINT [FK_dbo.OrderLines_dbo.Orders_Order_OrderId] FOREIGN KEY ([Order_OrderId]) 
        REFERENCES [dbo].[Orders] ([OrderId]) ON  DELETE CASCADE   ON UPDATE CASCADE
);
