using System;
using System.Collections.Generic;
using System.Text;
using ExpensesTrackerApp.Core.Account;

namespace ExpensesTrackerApp.Core.Services
{
    public interface IAutomaticTellerMachine
    {
        void AddIncome(AccountBase depositAccount, decimal amount);

        void AddExpenses(AccountBase account, decimal amount);

        //void Transfer(IWithdrawalAndDepositAccount from, IDepositAccount to, decimal amount);
    }
}
