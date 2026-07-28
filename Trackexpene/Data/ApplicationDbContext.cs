using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trackexpense.Models;

namespace Trackexpense.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Expense Table
        public DbSet<Expense> Expenses { get; set; }

        // Salary Table
        public DbSet<Salary> Salaries { get; set; }
    }
}