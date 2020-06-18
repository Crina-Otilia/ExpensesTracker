using System;
using System.Collections.Generic;
using System.Text;
using ExpensesTrackerApp.Core.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTrackerApp.DataAccess.SqlServer.Mappings
{
        class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts")
                            .HasKey(_ => _.Id);

            builder.Property(_ => _.Id).IsRequired();

            builder.Property(_ => _.Amount).HasColumnName("Amount");
            builder.Property(_ => _.Iban).HasColumnName("Iban").HasMaxLength(34);
            builder.Property(_ => _.AccountHolderId).HasColumnName("CustomerId");

            builder.HasOne(_ => _.AccountHolder)
                .WithMany();
/*
            builder.HasDiscriminator<int>("AccountTypeId")
                .HasValue<CreditAccount>(1)
                .HasValue<DebitAccount>(2)
                .HasValue<DepositAccount>(3)
                .HasValue<SavingsAccount>(4);
                */
        }
    }
}
