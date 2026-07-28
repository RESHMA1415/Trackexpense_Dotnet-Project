namespace Trackexpense.Models
{
    public class DashboardViewModel
    {
        // Summary Cards
        public decimal TotalIncome { get; set; }

        public decimal TotalExpense { get; set; }

        public decimal Balance { get; set; }

        public decimal PersonalExpense { get; set; }

        public decimal FamilyExpense { get; set; }


        // Monthly Salary Details
        public decimal MonthlySalary { get; set; }

        public decimal ThisMonthExpense { get; set; }

        public decimal RemainingSalary { get; set; }

        public decimal SalaryUsedPercentage { get; set; }

        public bool SalaryExceeded { get; set; }


        // Recent Transactions
        public List<Expense> RecentTransactions { get; set; }
            = new List<Expense>();


        // Category-wise Expense Chart
        public List<string> CategoryLabels { get; set; }
            = new List<string>();

        public List<decimal> CategoryAmounts { get; set; }
            = new List<decimal>();


        // Personal vs Family Chart
        public List<string> ExpenseForLabels { get; set; }
            = new List<string>();

        public List<decimal> ExpenseForAmounts { get; set; }
            = new List<decimal>();
    }
}