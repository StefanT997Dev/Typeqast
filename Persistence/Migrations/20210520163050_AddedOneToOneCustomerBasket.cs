using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedOneToOneCustomerBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "ShoppingBaskets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBaskets_CustomerId",
                table: "ShoppingBaskets",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingBaskets_AspNetUsers_CustomerId",
                table: "ShoppingBaskets",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingBaskets_AspNetUsers_CustomerId",
                table: "ShoppingBaskets");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingBaskets_CustomerId",
                table: "ShoppingBaskets");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ShoppingBaskets");
        }
    }
}
