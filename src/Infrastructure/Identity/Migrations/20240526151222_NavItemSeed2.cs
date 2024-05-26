using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nika1337.Library.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class NavItemSeed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6c45f08-65a7-4eab-8712-e14139810852");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a34f721-114d-43a3-894b-f4c5a24c56e5", null, "Consultant", "CONSULTANT" },
                    { "1dfbc71c-301a-41c0-a6a7-3eb188386e9b", null, "Librarian", "LIBRARIAN" },
                    { "561e1b91-491a-4376-bf0e-98f04777de4c", null, "Administrator", "ADMINISTRATOR" },
                    { "6613650a-c387-4311-9b97-14a89af589b6", null, "Human Resources Manager", "HUMAN RESOURCES MANAGER" },
                    { "e27ceda3-2b96-4486-9266-9247f22c106f", null, "Core Librarian", "CORE LIBRARIAN" }
                });

            migrationBuilder.InsertData(
                table: "IdentityEmployeeRoleNavigationMenuItem",
                columns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                values: new object[,]
                {
                    { "6613650a-c387-4311-9b97-14a89af589b6", 1 },
                    { "6613650a-c387-4311-9b97-14a89af589b6", 2 },
                    { "6613650a-c387-4311-9b97-14a89af589b6", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a34f721-114d-43a3-894b-f4c5a24c56e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dfbc71c-301a-41c0-a6a7-3eb188386e9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "561e1b91-491a-4376-bf0e-98f04777de4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e27ceda3-2b96-4486-9266-9247f22c106f");

            migrationBuilder.DeleteData(
                table: "IdentityEmployeeRoleNavigationMenuItem",
                keyColumns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                keyValues: new object[] { "6613650a-c387-4311-9b97-14a89af589b6", 1 });

            migrationBuilder.DeleteData(
                table: "IdentityEmployeeRoleNavigationMenuItem",
                keyColumns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                keyValues: new object[] { "6613650a-c387-4311-9b97-14a89af589b6", 2 });

            migrationBuilder.DeleteData(
                table: "IdentityEmployeeRoleNavigationMenuItem",
                keyColumns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                keyValues: new object[] { "6613650a-c387-4311-9b97-14a89af589b6", 3 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6613650a-c387-4311-9b97-14a89af589b6");

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
                table: "IdentityEmployeeRoleNavigationMenuItem",
                columns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                values: new object[,]
                {
                    { "a6c45f08-65a7-4eab-8712-e14139810852", 1 },
                    { "a6c45f08-65a7-4eab-8712-e14139810852", 2 },
                    { "a6c45f08-65a7-4eab-8712-e14139810852", 3 }
                });
        }
    }
}
