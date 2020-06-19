using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace ExpensesTrackerApp.DataAccess.SqlServer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExpensesTrackerAppContext dataContext;

        public UnitOfWork(ExpensesTrackerAppContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Commit()
        {
            using (var scope = new TransactionScope())
            {
                dataContext.SaveChanges();
                scope.Complete();
            }
        }
    }
}
