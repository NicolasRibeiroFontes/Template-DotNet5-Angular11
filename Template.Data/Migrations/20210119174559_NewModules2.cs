using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class NewModules2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Account");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 19, 17, 45, 58, 538, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 19, 17, 45, 58, 541, DateTimeKind.Local).AddTicks(223));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Accounts");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 19, 17, 29, 34, 774, DateTimeKind.Local).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 19, 17, 29, 34, 777, DateTimeKind.Local).AddTicks(5840));
        }
    }
}
