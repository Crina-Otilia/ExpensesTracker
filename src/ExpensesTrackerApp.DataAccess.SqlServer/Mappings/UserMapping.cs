using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ExpensesTrackerApp.Core.Identity;

namespace ExpensesTrackerApp.DataAccess.SqlServer.Mappings
{
    class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users")
                .HasKey(u => u.Id);
        }
    }
}
