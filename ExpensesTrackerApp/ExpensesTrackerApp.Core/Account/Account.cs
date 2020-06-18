using System;
using System.Collections.Generic;
using System.Text;
using ExpensesTrackerApp.Core.Account;
using ExpensesTrackerApp.Core;

namespace ExpensesTrackerApp.Core.Account
{
     public class Account:IEntity
    {
        public Account()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public Guid AccountHolderId { get; set; }

        public string Iban { get; set; }

        public decimal Amount { get; protected set; }

        public Customer AccountHolder { get; set; }
        
        public void Deposit(decimal amount){
            Amount+=amount;
        }
        public decimal Withdraw(decimal amount){
            if(Amount<amount){
                throw new InvalidOperationException("Insufficient funds!");
            }
            else Amount-=amount;
            return amount;
        }
    }
}
