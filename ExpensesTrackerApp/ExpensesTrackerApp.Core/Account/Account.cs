using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesTrackerApp.Core
{
    class Account
    {
        public decimal amount;
        public decimal income;
        public decimal expenses;

        public decimal Amount { get; private set; }
        public decimal Income { get; private set; }
        public decimal Expenses { get; private set; }

    }
}
