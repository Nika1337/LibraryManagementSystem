using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nika1337.Library.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class NavItemSeed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "Route",
                value: "/EmployeeManagement/AllEmployees");

            migrationBuilder.UpdateData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "Route",
                value: "/EmployeeManagement/AllEmployees");

            migrationBuilder.UpdateData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "Route",
                value: "/EmployeeManagement/RegisterEmployee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07b9c56b-082d-44c7-94f5-8239d965d681", null, "Consultant", "CONSULTANT" },
                    { "4b07c235-81f8-47ee-8100-cfb626cb0848", null, "Administrator", "ADMINISTRATOR" },
                    { "8983f885-d39e-4ac0-a4d5-576f9b4adfc8", null, "Librarian", "LIBRARIAN" },
                    { "ded207c7-7e7f-44b4-8b4a-a8681067c398", null, "Human Resources Manager", "HUMAN RESOURCES MANAGER" },
                    { "f20a11b7-9fb9-4964-993e-6304353c885d", null, "Core Librarian", "CORE LIBRARIAN" }
                });

            migrationBuilder.InsertData(
                table: "IdentityEmployeeRoleNavigationMenuItem",
                columns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                values: new object[,]
                {
                    { "ded207c7-7e7f-44b4-8b4a-a8681067c398", 1 },
                    { "ded207c7-7e7f-44b4-8b4a-a8681067c398", 2 },
                    { "ded207c7-7e7f-44b4-8b4a-a8681067c398", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07b9c56b-082d-44c7-94f5-8239d965d681");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b07c235-81f8-47ee-8100-cfb626cb0848");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8983f885-d39e-4ac0-a4d5-576f9b4adfc8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f20a11b7-9fb9-4964-993e-6304353c885d");

            migrationBuilder.DeleteData(
                table: "IdentityEmployeeRoleNavigationMenuItem",
                keyColumns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                keyValues: new object[] { "ded207c7-7e7f-44b4-8b4a-a8681067c398", 1 });

            migrationBuilder.DeleteData(
                table: "IdentityEmployeeRoleNavigationMenuItem",
                keyColumns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                keyValues: new object[] { "ded207c7-7e7f-44b4-8b4a-a8681067c398", 2 });

            migrationBuilder.DeleteData(
                table: "IdentityEmployeeRoleNavigationMenuItem",
                keyColumns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                keyValues: new object[] { "ded207c7-7e7f-44b4-8b4a-a8681067c398", 3 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ded207c7-7e7f-44b4-8b4a-a8681067c398");

            migrationBuilder.UpdateData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "Route",
                value: "EmployeeManagement/AllEmployees");

            migrationBuilder.UpdateData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "Route",
                value: "EmployeeManagement/AllEmployees");

            migrationBuilder.UpdateData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "Route",
                value: "EmployeeManagement/RegisterEmployee");

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
    }
}
