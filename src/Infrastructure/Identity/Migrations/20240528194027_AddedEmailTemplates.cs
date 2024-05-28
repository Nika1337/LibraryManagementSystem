using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nika1337.Library.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmailTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Separator = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4fd566f2-a166-4d32-9514-af55bd4dbf3b", null, "Core Librarian", "CORE LIBRARIAN" },
                    { "628cfb77-839d-4b02-b8a1-d476ad3a632b", null, "Operations Manager", "OPERATIONS MANAGER" },
                    { "ae28ed92-f864-4fff-8a2b-9bde35f51793", null, "Human Resources Manager", "HUMAN RESOURCES MANAGER" },
                    { "e6f08673-90d1-445f-a129-a251409059af", null, "Librarian", "LIBRARIAN" },
                    { "f4ebfc16-cd84-47f8-8d9a-07e258ec7f39", null, "Consultant", "CONSULTANT" }
                });

            migrationBuilder.InsertData(
                table: "IdentityEmployeeRoleNavigationMenuItem",
                columns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                values: new object[,]
                {
                    { "ae28ed92-f864-4fff-8a2b-9bde35f51793", 1 },
                    { "ae28ed92-f864-4fff-8a2b-9bde35f51793", 2 },
                    { "ae28ed92-f864-4fff-8a2b-9bde35f51793", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fd566f2-a166-4d32-9514-af55bd4dbf3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "628cfb77-839d-4b02-b8a1-d476ad3a632b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6f08673-90d1-445f-a129-a251409059af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4ebfc16-cd84-47f8-8d9a-07e258ec7f39");

            migrationBuilder.DeleteData(
                table: "IdentityEmployeeRoleNavigationMenuItem",
                keyColumns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                keyValues: new object[] { "ae28ed92-f864-4fff-8a2b-9bde35f51793", 1 });

            migrationBuilder.DeleteData(
                table: "IdentityEmployeeRoleNavigationMenuItem",
                keyColumns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                keyValues: new object[] { "ae28ed92-f864-4fff-8a2b-9bde35f51793", 2 });

            migrationBuilder.DeleteData(
                table: "IdentityEmployeeRoleNavigationMenuItem",
                keyColumns: new[] { "IdentityEmployeeRoleId", "NavigationMenuItemsId" },
                keyValues: new object[] { "ae28ed92-f864-4fff-8a2b-9bde35f51793", 3 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae28ed92-f864-4fff-8a2b-9bde35f51793");

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
    }
}
