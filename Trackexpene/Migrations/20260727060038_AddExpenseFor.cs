using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trackexpense.Migrations
{
    /// <inheritdoc />
    public partial class AddExpenseFor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExpenseFor",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpenseFor",
                table: "Expenses");
        }
    }
}
