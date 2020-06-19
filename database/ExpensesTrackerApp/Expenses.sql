CREATE TABLE [dbo].[Expenses]
(
	[Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_Expenses PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL,
	[CategoryId] UNIQUEIDENTIFIER NOT NULL,
	[Amount] DECIMAL(18, 2) NOT NULL, 
	 [Date] DATETIME NOT NULL, 
    CONSTRAINT [FK_Expenses_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id])
)
GO

CREATE UNIQUE INDEX [IX_Expenses_Name] ON [dbo].[Expenses] ([Name])

