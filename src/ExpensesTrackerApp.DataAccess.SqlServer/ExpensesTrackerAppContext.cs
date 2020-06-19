using ExpensesTrackerApp.Core.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
//using Microsoft.IdentityModel.Protocols;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ExpensesTrackerApp.DataAccess.SqlServer
{
    public class ExpensesTrackerAppContext : DbContext
    {
        private string connectionString;

        public ExpensesTrackerAppContext()
        {
        }
        public virtual DbSet<Expenses> ExpensesDB { get; set; }

       
        public ExpensesTrackerAppContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<AccountBase> Accounts { get; set; }
        public object Expenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = this.connectionString ?? System.Configuration.ConfigurationManager.ConnectionStrings["ExpensesTrackerApp"].ConnectionString;
            //var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ExpensesTrackerApp"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
            ///optionsBuilder.UseSqlServer(@"Data Source=localhost; Initial Catalog=ExpensesTrackerApp; Integrated Security=True; MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
