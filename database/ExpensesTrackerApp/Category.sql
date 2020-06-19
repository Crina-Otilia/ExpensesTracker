CREATE TABLE [dbo].[Category]
(
	[Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_Category PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL
)
GO

CREATE UNIQUE INDEX [IX_Category_Name] ON [dbo].[Category] ([Name])

