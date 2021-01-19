using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class NewModules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedUser", "Icon", "IsActive", "Name", "Sequence", "URL", "UpdatedData", "UpdatedUser" },
                values: new object[,]
                {
                    { 2, 0, "users.png", true, "Users", 2, "users", null, 0 },
                    { 3, 0, "accounts.png", true, "Accounts", 3, "accounts", null, 0 }
                });

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

            migrationBuilder.InsertData(
                table: "ModuleProfiles",
                columns: new[] { "ModuleId", "ProfileId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "ModuleProfiles",
                columns: new[] { "ModuleId", "ProfileId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "ModuleProfiles",
                columns: new[] { "ModuleId", "ProfileId" },
                values: new object[] { 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleProfiles",
                keyColumns: new[] { "ModuleId", "ProfileId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ModuleProfiles",
                keyColumns: new[] { "ModuleId", "ProfileId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ModuleProfiles",
                keyColumns: new[] { "ModuleId", "ProfileId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 18, 18, 26, 24, 908, DateTimeKind.Local).AddTicks(6061));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 18, 18, 26, 24, 911, DateTimeKind.Local).AddTicks(4755));
        }
    }
}
