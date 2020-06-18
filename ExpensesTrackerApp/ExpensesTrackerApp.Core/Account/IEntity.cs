using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesTrackerApp.Core.Account
{
    public interface IEntity
    {
        public Guid AccountHolderId { get; set; }

        decimal Amount { get; }

        string Iban { get; set; }

        void Deposit(decimal amount);
    }
}
