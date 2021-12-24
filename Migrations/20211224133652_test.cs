using Microsoft.EntityFrameworkCore.Migrations;

namespace Cheapy_API.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistory_Products_ProductId",
                table: "PaymentHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistory_Users_UserId",
                table: "PaymentHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentHistory",
                table: "PaymentHistory");

            migrationBuilder.RenameTable(
                name: "PaymentHistory",
                newName: "PaymentHistories");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentHistory_UserId",
                table: "PaymentHistories",
                newName: "IX_PaymentHistories_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentHistories",
                table: "PaymentHistories",
                columns: new[] { "ProductId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistories_Products_ProductId",
                table: "PaymentHistories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistories_Users_UserId",
                table: "PaymentHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistories_Products_ProductId",
                table: "PaymentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistories_Users_UserId",
                table: "PaymentHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentHistories",
                table: "PaymentHistories");

            migrationBuilder.RenameTable(
                name: "PaymentHistories",
                newName: "PaymentHistory");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentHistories_UserId",
                table: "PaymentHistory",
                newName: "IX_PaymentHistory_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentHistory",
                table: "PaymentHistory",
                columns: new[] { "ProductId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistory_Products_ProductId",
                table: "PaymentHistory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistory_Users_UserId",
                table: "PaymentHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
