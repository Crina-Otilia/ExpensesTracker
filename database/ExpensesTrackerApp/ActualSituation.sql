CREATE TABLE [dbo].[ActualSituation]
(
	[Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_ActualSituation_Id] DEFAULT (newid()) NOT NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [IncomeId]   UNIQUEIDENTIFIER NOT NULL,
    [ExpensesId]  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_ActualSituation_User] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
    CONSTRAINT [FK_ActualSituation_Income] FOREIGN KEY ([IncomeId]) REFERENCES [Income]([Id]),
    CONSTRAINT [FK_ActualSituation_Expenses] FOREIGN KEY ([ExpensesId]) REFERENCES [Expenses]([Id])
)
