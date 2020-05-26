using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesTrackerApp.Core
{
    class Customer:IEntityBase
    {
        public Customer()
        {
            Income = new List<Income>();
            Expenses = new List<Expenses>();
        }

        public Guid Id { get; set; }

        public string IdNo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public virtual IList<Income> Income { get; set; }

        public virtual IList<Expenses> Expenses { get; set; }
    }
}
