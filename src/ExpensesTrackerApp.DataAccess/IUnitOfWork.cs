using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesTrackerApp.DataAccess
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
