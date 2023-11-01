using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaOrderingApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMenuCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.CreateTable(
			name: "MenuCategories",
			columns: table => new
			{
			  CategoryID = table.Column<int>(type: "INTEGER", nullable: false)
			   .Annotation("Sqlite:Autoincrement", true),
			  CategoryName = table.Column<string>(type: "TEXT", nullable: true)
		    },
		    constraints: table =>
			{
				table.PrimaryKey("PK_MenuCategories", x => x.CategoryID);
			});
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
