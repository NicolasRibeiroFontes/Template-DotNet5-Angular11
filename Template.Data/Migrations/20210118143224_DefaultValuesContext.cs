using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class DefaultValuesContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleProfiles_Modules_ModuleId",
                table: "ModuleProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleProfiles_Profiles_ProfileId",
                table: "ModuleProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Profiles_ProfileId",
                table: "Users");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Profiles",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Profiles",
                type: "datetime",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Modules",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Modules",
                type: "datetime",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedUser", "Icon", "IsActive", "Name", "Sequence", "URL", "UpdatedData", "UpdatedUser" },
                values: new object[] { 1, 0, "dashboard.png", true, "Dashboard", 1, "dashboard", null, 0 });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedUser", "IsActive", "IsDefault", "Name", "UpdatedData", "UpdatedUser" },
                values: new object[] { 1, 0, true, false, "Admin", null, 0 });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedUser", "IsActive", "IsDefault", "Name", "UpdatedData", "UpdatedUser" },
                values: new object[] { 2, 0, true, false, "User", null, 0 });

            migrationBuilder.InsertData(
                table: "ModuleProfiles",
                columns: new[] { "ModuleId", "ProfileId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Code", "CreatedDate", "CreatedUser", "Email", "IsActive", "IsAuthorised", "Name", "Password", "ProfileId", "UpdatedData", "UpdatedUser" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 1, 18, 14, 32, 23, 775, DateTimeKind.Local).AddTicks(6768), 1, "admin@template.com", true, true, "Admin", "8D66A53A381493BEC08DA23CEF5A43767F20A42C", 1, null, 0 },
                    { 2, null, new DateTime(2021, 1, 18, 14, 32, 23, 778, DateTimeKind.Local).AddTicks(3754), 1, "user@template.com", true, true, "User", "8D66A53A381493BEC08DA23CEF5A43767F20A42C", 2, null, 0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleProfiles_Modules_ModuleId",
                table: "ModuleProfiles",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleProfiles_Profiles_ProfileId",
                table: "ModuleProfiles",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Profiles_ProfileId",
                table: "Users",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleProfiles_Modules_ModuleId",
                table: "ModuleProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleProfiles_Profiles_ProfileId",
                table: "ModuleProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Profiles_ProfileId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "ModuleProfiles",
                keyColumns: new[] { "ModuleId", "ProfileId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ModuleProfiles",
                keyColumns: new[] { "ModuleId", "ProfileId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Profiles",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Profiles",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Modules",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Modules",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleProfiles_Modules_ModuleId",
                table: "ModuleProfiles",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleProfiles_Profiles_ProfileId",
                table: "ModuleProfiles",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Profiles_ProfileId",
                table: "Users",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
