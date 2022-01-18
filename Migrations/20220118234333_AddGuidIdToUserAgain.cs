using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cheapy_API.Migrations
{
    public partial class AddGuidIdToUserAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_AdvertiserId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Orders",
                newName: "UserCPF");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 18, 20, 43, 32, 908, DateTimeKind.Local).AddTicks(724),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 15, 18, 14, 56, 126, DateTimeKind.Local).AddTicks(1515));

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Users",
                type: "TEXT",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "AdvertiserId",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CPF",
                table: "Users",
                column: "CPF");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_AdvertiserId",
                table: "Products",
                column: "AdvertiserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_AdvertiserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Users_CPF",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserCPF",
                table: "Orders",
                newName: "UserEmail");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 15, 18, 14, 56, 126, DateTimeKind.Local).AddTicks(1515),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 18, 20, 43, 32, 908, DateTimeKind.Local).AddTicks(724));

            migrationBuilder.AlterColumn<string>(
                name: "AdvertiserId",
                table: "Products",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_AdvertiserId",
                table: "Products",
                column: "AdvertiserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
