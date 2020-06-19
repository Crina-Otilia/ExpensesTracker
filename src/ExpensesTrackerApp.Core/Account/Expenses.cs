using System;
using System.Collections.Generic;
using System.Text;
using ExpensesTrackerApp.Core.Account;
using ExpensesTrackerApp.Core;


namespace ExpensesTrackerApp.Core.Account
{
    public class Expenses: AccountBase,IEntity
    {
        public int Id { get; set; }

        public Guid Name { get; set; }

        public string Iban { get; set; }

        public decimal Amount { get; protected set; }

        public DateTime ExpenseDate { get; set; } = DateTime.Now;
        public string Category { get; set; }
    }
}
