using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesTrackerApp.Core.Identity
{
    public class Role:IEntityBase
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
