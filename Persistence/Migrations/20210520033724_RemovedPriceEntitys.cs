using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RemovedPriceEntitys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Prices_PriceId",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Prices_PriceId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Products_PriceId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_PriceId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Discounts");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "PriceId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PriceId",
                table: "Discounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PriceId",
                table: "Products",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_PriceId",
                table: "Discounts",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Prices_PriceId",
                table: "Discounts",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Prices_PriceId",
                table: "Products",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
