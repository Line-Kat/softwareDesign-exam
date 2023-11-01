using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaOrderingApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuItem : Migration
    {
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "MenuItems",
				columns: table => new
				{
					ItemID = table.Column<int>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					ItemName = table.Column<string>(type: "TEXT", nullable: true),
					Price = table.Column<decimal>(type: "TEXT", nullable: false),
					Description = table.Column<string>(type: "TEXT", nullable: true),
					CategoryID = table.Column<int>(type: "INTEGER", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_MenuItems", x => x.ItemID);
					table.ForeignKey(
						name: "FK_MenuItems_MenuCategories_CategoryID",
						column: x => x.CategoryID,
						principalTable: "MenuCategories",
						principalColumn: "CategoryID",
						onDelete: ReferentialAction.Cascade);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "MenuItems");
		}
	}
}
