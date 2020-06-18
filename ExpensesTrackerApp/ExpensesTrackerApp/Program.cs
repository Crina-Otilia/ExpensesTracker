using System;

namespace ExpensesTrackerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var account=new Core.Account.AccountBase();
            account.Deposit(110);
            account.Withdraw(10);

            
            
            Console.WriteLine("Incercare.");
        }
    }
}
