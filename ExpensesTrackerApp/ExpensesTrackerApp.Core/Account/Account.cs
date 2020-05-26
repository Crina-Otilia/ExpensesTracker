using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesTrackerApp.Core
{
    abstract class Account
    {
        public decimal amount;
        public decimal income;
        public decimal expenses;

        public decimal Amount { get; private set; }
        //protected abstract decimal Income (decimal amount){}
        //protected abstract decimal Expenses (decimal amount){}

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
