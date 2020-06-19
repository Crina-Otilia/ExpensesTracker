using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesTrackerApp.Core
{
    public interface IEntityBase
    {
        public Guid Id { get; set; }
    }
}
