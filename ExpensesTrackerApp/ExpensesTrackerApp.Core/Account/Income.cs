using System;
using System.Collections.Generic;
using System.Text;
using ExpensesTrackerApp.Core.Account;
using ExpensesTrackerApp.Core;

namespace ExpensesTrackerApp.Core.Account
{
    public class Income : AccountBase, IEntity
    {
        public int Id { get; set; }

        public Guid AccountHolderId { get; set; }

        public string Iban { get; set; }

        public decimal Amount { get; protected set; }

        public Customer AccountHolder { get; set; }
    }
}
