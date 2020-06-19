using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExpensesTrackerApp.Core.Identity;

namespace ExpensesTrackerApp.DataAccess.SqlServer.Mappings
{
    class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles")
                .HasKey(r => r.Id);
        }
    }
}
