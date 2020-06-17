using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesTrackerApp.Core.Account
{
     public class Account:IEntity
    {

        public decimal Amount { get; private set; }
        public int Id { get; set; }
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
