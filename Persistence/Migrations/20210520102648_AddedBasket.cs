using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingBaskets_AspNetUsers_CustomerId",
                table: "ShoppingBaskets");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingBaskets_Products_ProductId",
                table: "ShoppingBaskets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingBaskets",
                table: "ShoppingBaskets");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingBaskets_ProductId",
                table: "ShoppingBaskets");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ShoppingBaskets");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ShoppingBaskets",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfItems",
                table: "ShoppingBaskets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "ShoppingBaskets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingBaskets",
                table: "ShoppingBaskets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ShoppingBasketPairs",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoppingBasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingBasketPairs", x => new { x.CustomerId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ShoppingBasketPairs_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingBasketPairs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingBasketPairs_ShoppingBaskets_ShoppingBasketId",
                        column: x => x.ShoppingBasketId,
                        principalTable: "ShoppingBaskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBasketPairs_ProductId",
                table: "ShoppingBasketPairs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBasketPairs_ShoppingBasketId",
                table: "ShoppingBasketPairs",
                column: "ShoppingBasketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingBasketPairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingBaskets",
                table: "ShoppingBaskets");

            migrationBuilder.DropColumn(
                name: "NumberOfItems",
                table: "ShoppingBaskets");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ShoppingBaskets");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShoppingBaskets",
                newName: "ProductId");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "ShoppingBaskets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingBaskets",
                table: "ShoppingBaskets",
                columns: new[] { "CustomerId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBaskets_ProductId",
                table: "ShoppingBaskets",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingBaskets_AspNetUsers_CustomerId",
                table: "ShoppingBaskets",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingBaskets_Products_ProductId",
                table: "ShoppingBaskets",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
