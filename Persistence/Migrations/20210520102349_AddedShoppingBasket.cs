using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedShoppingBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SumPrice",
                table: "ShoppingBaskets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SumPrice",
                table: "ShoppingBaskets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
