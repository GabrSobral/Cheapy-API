using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cheapy_API.Migrations
{
    public partial class AddCategoryProductTableFix4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesProducts_Categories_CategoryId",
                table: "CategoriesProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesProducts_Products_ProductId",
                table: "CategoriesProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriesProducts",
                table: "CategoriesProducts");

            migrationBuilder.DropIndex(
                name: "IX_CategoriesProducts_CategoryId",
                table: "CategoriesProducts");

            migrationBuilder.DropColumn(
                name: "Category_Id",
                table: "CategoriesProducts");

            migrationBuilder.DropColumn(
                name: "Product_Id",
                table: "CategoriesProducts");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "CategoriesProducts",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "CategoriesProducts",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriesProducts",
                table: "CategoriesProducts",
                columns: new[] { "CategoryId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesProducts_Categories_CategoryId",
                table: "CategoriesProducts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesProducts_Products_ProductId",
                table: "CategoriesProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesProducts_Categories_CategoryId",
                table: "CategoriesProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesProducts_Products_ProductId",
                table: "CategoriesProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriesProducts",
                table: "CategoriesProducts");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "CategoriesProducts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "CategoriesProducts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "Category_Id",
                table: "CategoriesProducts",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Product_Id",
                table: "CategoriesProducts",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriesProducts",
                table: "CategoriesProducts",
                columns: new[] { "Category_Id", "Product_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesProducts_CategoryId",
                table: "CategoriesProducts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesProducts_Categories_CategoryId",
                table: "CategoriesProducts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesProducts_Products_ProductId",
                table: "CategoriesProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
