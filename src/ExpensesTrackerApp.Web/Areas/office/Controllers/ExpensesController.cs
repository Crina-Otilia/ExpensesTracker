using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesTrackerApp.Web.Areas.office.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExpensesTrackerApp.Core.Account;

namespace ExpensesTrackerApp.Web.Areas.office.Controllers
{
    public class ExpenseController : Controller
    {
        ExpensesData objexpense = new ExpensesData();
        

        public ActionResult AddEditExpenses(int Id)
        {
            Expenses model = new Expenses();
            if (Id > 0)
            {
                model = objexpense.GetExpenseData(Id);
            }
            return PartialView("_expenseForm", model);
        }

        [HttpPost]
        public ActionResult Create(Expenses newExpense)
        {
            if (ModelState.IsValid)
            {
                if (newExpense.Id > 0)
                {
                    objexpense.UpdateExpense(newExpense);
                }
                else
                {
                    objexpense.AddExpense(newExpense);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            objexpense.DeleteExpense(id);
            return RedirectToAction("Index");
        }

        public ActionResult ExpenseSummary()
        {
            return PartialView("_expenseReport");
        }

        public JsonResult GetMonthlyExpense()
        {
            Dictionary<string, decimal> monthlyExpense = objexpense.CalculateMonthlyExpense();
            return new JsonResult(monthlyExpense);
        }

        public JsonResult GetWeeklyExpense()
        {
            Dictionary<string, decimal> weeklyExpense = objexpense.CalculateWeeklyExpense();
            return new JsonResult(weeklyExpense);
        }
    }
}