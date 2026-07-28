using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trackexpense.Data;
using Trackexpense.Models;

namespace Trackexpense.Controllers
{
    public class SalaryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalaryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Salary
        public async Task<IActionResult> Index()
        {
            var salaries = await _context.Salaries
                .OrderByDescending(s => s.Year)
                .ThenByDescending(s => s.Month)
                .ToListAsync();

            return View(salaries);
        }

        // GET: Salary/Create
        public IActionResult Create()
        {
            var salary = new Salary
            {
                Month = DateTime.Now.Month,
                Year = DateTime.Now.Year
            };

            return View(salary);
        }

        // POST: Salary/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Salary salary)
        {
            if (!ModelState.IsValid)
            {
                return View(salary);
            }

            // Check whether salary already exists
            // for the selected month and year
            var existingSalary = await _context.Salaries
                .FirstOrDefaultAsync(s =>
                    s.Month == salary.Month &&
                    s.Year == salary.Year);

            if (existingSalary != null)
            {
                // If already exists, update amount
                existingSalary.Amount = salary.Amount;

                _context.Salaries.Update(existingSalary);
            }
            else
            {
                // Otherwise create new salary
                _context.Salaries.Add(salary);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}