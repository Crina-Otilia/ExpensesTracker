﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesTrackerApp.Core
{
    class User:IEntityBase
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}
