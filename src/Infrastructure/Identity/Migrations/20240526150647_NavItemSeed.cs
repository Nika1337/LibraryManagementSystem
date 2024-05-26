using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nika1337.Library.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class NavItemSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "148f1856-58e7-4a33-aa1b-b2783589ad89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b0660dd-26e4-4e63-a245-2b023c032cd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "622e07aa-e69c-4ba6-9c8e-57bb8a1d052f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ca6afb2-7af2-48f2-9c2c-3ac2ccb22da1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9d90ad5-aee4-47bf-a3ea-29913a89b696");

            migrationBuilder.InsertData(
                table: "AspNetNavigationMenuItem",
                columns: new[] { "Id", "Name", "ParentNavigationMenuItemId", "Route" },
                values: new object[] { 1, "Employees", null, "EmployeeManagement/AllEmployees" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "49d06b78-b951-4747-9b69-0d94e35bf0b9", null, "Consultant", "CONSULTANT" },
                    { "7972f308-947e-431c-b915-f112d259f642", null, "Core Librarian", "CORELIBRARIAN" },
                    { "a6c45f08-65a7-4eab-8712-e14139810852", null, "Human Resources Manager", "HUMAN RESOURCES MANAGER" },
                    { "b4aff430-927f-4bf8-aaab-d2c536ac9d2b", null, "Librarian", "LIBRARIAN" },
                    { "b61bcf6a-f73c-47f9-bfa1-b71ccf7a79f7", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetNavigationMenuItem",
                columns: new[] { "Id", "Name", "ParentNavigationMenuItemId", "Route" },
                values: new object[,]
                {
                    { 2, "All Employees", 1, "EmployeeManagement/AllEmployees" },
                    { 3, "Register Employee", 1, "EmployeeManagement/RegisterEmployee" }
                });

            migrationBuilder.InsertData(
                table: "IdentityEmployeeRoleNavigationMenuItem",
                columns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                values: new object[,]
                {
                    { "a6c45f08-65a7-4eab-8712-e14139810852", 1 },
                    { "a6c45f08-65a7-4eab-8712-e14139810852", 2 },
                    { "a6c45f08-65a7-4eab-8712-e14139810852", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49d06b78-b951-4747-9b69-0d94e35bf0b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7972f308-947e-431c-b915-f112d259f642");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4aff430-927f-4bf8-aaab-d2c536ac9d2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b61bcf6a-f73c-47f9-bfa1-b71ccf7a79f7");

            migrationBuilder.DeleteData(
                table: "IdentityEmployeeRoleNavigationMenuItem",
                keyColumns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                keyValues: new object[] { "a6c45f08-65a7-4eab-8712-e14139810852", 1 });

            migrationBuilder.DeleteData(
                table: "IdentityEmployeeRoleNavigationMenuItem",
                keyColumns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                keyValues: new object[] { "a6c45f08-65a7-4eab-8712-e14139810852", 2 });

            migrationBuilder.DeleteData(
                table: "IdentityEmployeeRoleNavigationMenuItem",
                keyColumns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                keyValues: new object[] { "a6c45f08-65a7-4eab-8712-e14139810852", 3 });

            migrationBuilder.DeleteData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6c45f08-65a7-4eab-8712-e14139810852");

            migrationBuilder.DeleteData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "148f1856-58e7-4a33-aa1b-b2783589ad89", null, "Administrator", "ADMINISTRATOR" },
                    { "2b0660dd-26e4-4e63-a245-2b023c032cd3", null, "Consultant", "CONSULTANT" },
                    { "622e07aa-e69c-4ba6-9c8e-57bb8a1d052f", null, "Core Librarian", "CORELIBRARIAN" },
                    { "7ca6afb2-7af2-48f2-9c2c-3ac2ccb22da1", null, "Librarian", "LIBRARIAN" },
                    { "e9d90ad5-aee4-47bf-a3ea-29913a89b696", null, "Human Resources Manager", "HRMANAGER" }
                });
        }
    }
}
