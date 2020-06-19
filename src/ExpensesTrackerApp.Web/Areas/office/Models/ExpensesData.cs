using ExpensesTrackerApp.Core.Account;
using ExpensesTrackerApp.DataAccess.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExpensesTrackerApp.Web.Areas.office.Models
{
    public class ExpensesData
    {
        
            ExpensesTrackerAppContext db = new ExpensesTrackerAppContext();
            public IEnumerable<Expenses> GetAllExpenses()
            {
                try
                {
                    return db.ExpensesDB.ToList();
                }
                catch
                {
                    throw;
                }
            }

           

            //To Add new Expense record       
            public void AddExpense(Expenses expense)
            {
                try
                {
                    db.ExpensesDB.Add(expense);
                    db.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }

            //To Update the records of a particluar expense  
            public int UpdateExpense(Expenses expense)
            {
                try
                {
                    db.Entry(expense).State = EntityState.Modified;
                    db.SaveChanges();

                    return 1;
                }
                catch
                {
                    throw;
                }
            }

            //Get the data for a particular expense  
            public Expenses GetExpenseData(int id)
            {
                try
                {
                    Expenses expense = db.ExpensesDB.Find(id);
                    return expense;
                }
                catch
                {
                    throw;
                }
            }

            //To Delete the record of a particular expense  
            public void DeleteExpense(int id)
            {
                try
                {
                    Expenses emp = db.ExpensesDB.Find(id);
                    db.ExpensesDB.Remove(emp);
                    db.SaveChanges();

                }
                catch
                {
                    throw;
                }
            }

            // To calculate last six months expense
            public Dictionary<string, decimal> CalculateMonthlyExpense()
            {
                ExpensesData objexpense = new ExpensesData();
                List<Expenses> lstEmployee = new List<Expenses>();

                Dictionary<string, decimal> dictMonthlySum = new Dictionary<string, decimal>();

                decimal foodSum = db.ExpensesDB.Where
                    (cat => cat.Category == "Food" && (cat.ExpenseDate > DateTime.Now.AddMonths(-7)))
                    .Select(cat => cat.Amount)
                    .Sum();

                decimal shoppingSum = db.ExpensesDB.Where
                   (cat => cat.Category == "Shopping" && (cat.ExpenseDate > DateTime.Now.AddMonths(-7)))
                   .Select(cat => cat.Amount)
                   .Sum();

                decimal travelSum = db.ExpensesDB.Where
                   (cat => cat.Category == "Travel" && (cat.ExpenseDate > DateTime.Now.AddMonths(-7)))
                   .Select(cat => cat.Amount)
                   .Sum();

                decimal healthSum = db.ExpensesDB.Where
                   (cat => cat.Category == "Health" && (cat.ExpenseDate > DateTime.Now.AddMonths(-7)))
                   .Select(cat => cat.Amount)
                   .Sum();

                dictMonthlySum.Add("Food", foodSum);
                dictMonthlySum.Add("Shopping", shoppingSum);
                dictMonthlySum.Add("Travel", travelSum);
                dictMonthlySum.Add("Health", healthSum);

                return dictMonthlySum;
            }

            // To calculate last four weeks expense
            public Dictionary<string, decimal> CalculateWeeklyExpense()
            {
                ExpensesData objexpense = new ExpensesData();
                List<Expenses> lstEmployee = new List<Expenses>();

                Dictionary<string, decimal> dictWeeklySum = new Dictionary<string, decimal>();

                decimal foodSum = db.ExpensesDB.Where
                    (cat => cat.Category == "Food" && (cat.ExpenseDate > DateTime.Now.AddDays(-7)))
                    .Select(cat => cat.Amount)
                    .Sum();

                decimal shoppingSum = db.ExpensesDB.Where
                   (cat => cat.Category == "Shopping" && (cat.ExpenseDate > DateTime.Now.AddDays(-28)))
                   .Select(cat => cat.Amount)
                   .Sum();

                decimal travelSum = db.ExpensesDB.Where
                   (cat => cat.Category == "Travel" && (cat.ExpenseDate > DateTime.Now.AddDays(-28)))
                   .Select(cat => cat.Amount)
                   .Sum();

                decimal healthSum = db.ExpensesDB.Where
                   (cat => cat.Category == "Health" && (cat.ExpenseDate > DateTime.Now.AddDays(-28)))
                   .Select(cat => cat.Amount)
                   .Sum();

                dictWeeklySum.Add("Food", foodSum);
                dictWeeklySum.Add("Shopping", shoppingSum);
                dictWeeklySum.Add("Travel", travelSum);
                dictWeeklySum.Add("Health", healthSum);

                return dictWeeklySum;
            }
        
    }
}
