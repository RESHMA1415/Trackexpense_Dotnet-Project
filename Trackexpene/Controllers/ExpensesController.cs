using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trackexpense.Models;
using Trackexpense.Data;

public class ExpensesController : Controller
{
    private readonly ApplicationDbContext _context;

    public ExpensesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Expenses
    // Search + Filter
    public async Task<IActionResult> Index(
        string? search,
        string? type,
        string? expenseFor,
        int? month)
    {
        var expenses = _context.Expenses.AsQueryable();

        // Search by Title or Category
        if (!string.IsNullOrWhiteSpace(search))
        {
            expenses = expenses.Where(e =>
                e.Title.Contains(search) ||
                e.Category.Contains(search));
        }

        // Filter by Income / Expense
        if (!string.IsNullOrWhiteSpace(type))
        {
            expenses = expenses.Where(e =>
                e.Type == type);
        }

        // Filter by Personal / Family
        if (!string.IsNullOrWhiteSpace(expenseFor))
        {
            expenses = expenses.Where(e =>
                e.ExpenseFor == expenseFor);
        }

        // Filter by Month
        if (month.HasValue)
        {
            expenses = expenses.Where(e =>
                e.Date.Month == month.Value);
        }

        // Store selected filter values
        ViewBag.Search = search;
        ViewBag.Type = type;
        ViewBag.ExpenseFor = expenseFor;
        ViewBag.Month = month;

        // Latest transaction first
    return View(await expenses
            .OrderByDescending(e => e.Date)
            .ThenByDescending(e => e.Id)
            .ToListAsync());
    }

    // GET: Expenses/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var expense = await _context.Expenses
            .FirstOrDefaultAsync(m => m.Id == id);

        if (expense == null)
        {
            return NotFound();
        }

        return View(expense);
    }

    // GET: Expenses/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Expenses/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Id,Title,Amount,Category,Type,ExpenseFor,Date,Notes")]
        Expense expense)
    {
        if (ModelState.IsValid)
        {
            _context.Add(expense);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(expense);
    }

    // GET: Expenses/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var expense = await _context.Expenses.FindAsync(id);

        if (expense == null)
        {
            return NotFound();
        }

        return View(expense);
    }

    // POST: Expenses/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int? id,
        [Bind("Id,Title,Amount,Category,Type,ExpenseFor,Date,Notes")]
        Expense expense)
    {
        if (id != expense.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(expense);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(expense.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(expense);
    }

    // GET: Expenses/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var expense = await _context.Expenses
            .FirstOrDefaultAsync(m => m.Id == id);

        if (expense == null)
        {
            return NotFound();
        }

        return View(expense);
    }

    // POST: Expenses/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var expense = await _context.Expenses.FindAsync(id);

        if (expense != null)
        {
            _context.Expenses.Remove(expense);
        }

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // Check Expense Exists
    private bool ExpenseExists(int? id)
    {
        return _context.Expenses.Any(e => e.Id == id);
    }
}