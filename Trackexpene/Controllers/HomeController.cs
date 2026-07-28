using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Trackexpene.Models;
using Trackexpense.Data;
using Trackexpense.Models;

namespace Trackexpense.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // --------------------------------
            // Current Month & Year
            // --------------------------------
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;


            // --------------------------------
            // Total Income
            // --------------------------------
            var totalIncome = await _context.Expenses
                .Where(x => x.Type == "Income")
                .SumAsync(x => (decimal?)x.Amount) ?? 0;


            // --------------------------------
            // Total Expense
            // --------------------------------
            var totalExpense = await _context.Expenses
                .Where(x => x.Type == "Expense")
                .SumAsync(x => (decimal?)x.Amount) ?? 0;


            // --------------------------------
            // Personal Expense
            // --------------------------------
            var personalExpense = await _context.Expenses
                .Where(x =>
                    x.Type == "Expense" &&
                    x.ExpenseFor == "Personal")
                .SumAsync(x => (decimal?)x.Amount) ?? 0;


            // --------------------------------
            // Family Expense
            // --------------------------------
            var familyExpense = await _context.Expenses
                .Where(x =>
                    x.Type == "Expense" &&
                    x.ExpenseFor == "Family")
                .SumAsync(x => (decimal?)x.Amount) ?? 0;


            // --------------------------------
            // Current Month Salary
            // --------------------------------
            var salaryRecord = await _context.Salaries
                .FirstOrDefaultAsync(s =>
                    s.Month == currentMonth &&
                    s.Year == currentYear);

            decimal monthlySalary =
                salaryRecord?.Amount ?? 0;


            // --------------------------------
            // Current Month Expense
            // --------------------------------
            var thisMonthExpense = await _context.Expenses
                .Where(x =>
                    x.Type == "Expense" &&
                    x.Date.Month == currentMonth &&
                    x.Date.Year == currentYear)
                .SumAsync(x => (decimal?)x.Amount) ?? 0;


            // --------------------------------
            // Remaining Salary
            // --------------------------------
            decimal remainingSalary =
                monthlySalary - thisMonthExpense;


            // --------------------------------
            // Salary Used Percentage
            // --------------------------------
            decimal salaryUsedPercentage = 0;

            if (monthlySalary > 0)
            {
                salaryUsedPercentage =
                    (thisMonthExpense / monthlySalary) * 100;
            }


            // --------------------------------
            // Salary Exceeded?
            // --------------------------------
            bool salaryExceeded =
                monthlySalary > 0 &&
                thisMonthExpense > monthlySalary;


            // --------------------------------
            // Recent Transactions
            // --------------------------------
            var recentTransactions = await _context.Expenses
                .OrderByDescending(x => x.Date)
                .ThenByDescending(x => x.Id)
                .Take(5)
                .ToListAsync();


            // --------------------------------
            // Category-wise Expense Chart
            // --------------------------------
            var categoryData = await _context.Expenses
                .Where(x => x.Type == "Expense")
                .GroupBy(x => x.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Amount = g.Sum(x => x.Amount)
                })
                .OrderByDescending(x => x.Amount)
                .ToListAsync();


            // --------------------------------
            // Personal vs Family Chart
            // --------------------------------
            var expenseForData = await _context.Expenses
                .Where(x =>
                    x.Type == "Expense" &&
                    (x.ExpenseFor == "Personal" ||
                     x.ExpenseFor == "Family"))
                .GroupBy(x => x.ExpenseFor)
                .Select(g => new
                {
                    ExpenseFor = g.Key,
                    Amount = g.Sum(x => x.Amount)
                })
                .ToListAsync();


            // --------------------------------
            // Dashboard ViewModel
            // --------------------------------
            var dashboard = new DashboardViewModel
            {
                // Main Summary
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                Balance = totalIncome - totalExpense,

                PersonalExpense = personalExpense,
                FamilyExpense = familyExpense,


                // Salary Summary
                MonthlySalary = monthlySalary,
                ThisMonthExpense = thisMonthExpense,
                RemainingSalary = remainingSalary,
                SalaryUsedPercentage = salaryUsedPercentage,
                SalaryExceeded = salaryExceeded,


                // Recent Transactions
                RecentTransactions = recentTransactions,


                // Category Chart
                CategoryLabels = categoryData
                    .Select(x => x.Category)
                    .ToList(),

                CategoryAmounts = categoryData
                    .Select(x => x.Amount)
                    .ToList(),


                // Personal / Family Chart
                ExpenseForLabels = expenseForData
                    .Select(x => x.ExpenseFor)
                    .ToList(),

                ExpenseForAmounts = expenseForData
                    .Select(x => x.Amount)
                    .ToList()
            };


            return View(dashboard);
        }


        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId =
                    Activity.Current?.Id
                    ?? HttpContext.TraceIdentifier
            });
        }
    }
}