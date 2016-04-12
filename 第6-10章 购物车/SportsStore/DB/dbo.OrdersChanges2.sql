CREATE TABLE [dbo].[Orders] (
    [OrderId]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [Phone]      NVARCHAR (MAX) NULL,
    [AddrInfo]      NVARCHAR (MAX) NULL,
    [Comments]      NVARCHAR (MAX) NULL,
    [City]       NVARCHAR (MAX) NULL,
    [State]      NVARCHAR (MAX) NULL,
    [GiftWrap]   BIT            NOT NULL,
    [Dispatched] BIT            NOT NULL,
    CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED ([OrderId] ASC)
);

