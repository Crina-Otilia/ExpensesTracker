using System;
using System.Collections.Generic;
using System.Text;
using ExpensesTrackerApp.Core.Account;
using ExpensesTrackerApp.Core;


namespace ExpensesTrackerApp.Core.Account
{
    public class Expenses: Account,IEntity
    {
        public int Id { get; set; }
    }
}
