using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ExpensesTrackerApp.Core;


namespace ExpensesTrackerApp.DataAccess.SqlServer.Mappings
{
    class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers")
                .HasKey(_ => _.Id);

            builder.Property(_ => _.FullName).HasColumnName("FullName").ValueGeneratedOnAddOrUpdate();

            builder.HasMany(_ => _.Expenses)
                .WithOne(_ => _.AccountHolder);
        }
    }
}
