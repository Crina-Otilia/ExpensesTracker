using System;
using System.Collections.Generic;
using System.Text;
using ExpensesTrackerApp.Core.Account;

namespace ExpensesTrackerApp.Core.Services
{
    public class AutomaticTellerMachine : IAutomaticTellerMachine
    {
        public void AddIncome(AccountBase depositAccount, decimal amount)
        {
            depositAccount.Deposit(amount);
        }

        public void AddExpenses(AccountBase account, decimal amount)
        {
            
            if (amount > account.Amount)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }
            account.Withdraw(amount);
            Console.WriteLine("{0}: {1}", account.GetType().Name, account.Amount);
        }

    }
}
