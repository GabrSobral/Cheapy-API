using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cheapy_API.Migrations
{
    public partial class AddRefreshTokenRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 26, 8, 34, 14, 949, DateTimeKind.Local).AddTicks(7832),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 26, 8, 32, 20, 775, DateTimeKind.Local).AddTicks(6697));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 26, 8, 32, 20, 775, DateTimeKind.Local).AddTicks(6697),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 26, 8, 34, 14, 949, DateTimeKind.Local).AddTicks(7832));
        }
    }
}
