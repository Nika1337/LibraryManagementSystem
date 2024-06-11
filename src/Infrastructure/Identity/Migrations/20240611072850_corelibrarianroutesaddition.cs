using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nika1337.Library.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class corelibrarianroutesaddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ec7d765-23cf-4924-98b4-59cb9ad48b29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b82de6e-e0d0-4756-b832-13bed3063b0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc920de8-6ecf-4c51-bb3e-33235c0359a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfe48fc2-c6c6-49e2-99b0-169c14face3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8a5a82a-2f5c-4500-ab3f-f46cc4d1f0ca");

            migrationBuilder.InsertData(
                table: "AspNetNavigationMenuItem",
                columns: new[] { "Id", "Name", "ParentNavigationMenuItemId", "Route" },
                values: new object[,]
                {
                    { 15, "Genres", 6, null },
                    { 18, "Languages", 6, null },
                    { 21, "Author", null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02639985-77a9-4b02-954d-bc4b0cdad51f", null, "Librarian", "LIBRARIAN" },
                    { "45d8d084-207a-414f-8fcf-c465024c375a", null, "Operations Manager", "OPERATIONS MANAGER" },
                    { "618cbc5a-0310-4a43-aa79-aa188d3183e8", null, "Human Resources Manager", "HUMAN RESOURCES MANAGER" },
                    { "cc8677c1-73c1-4109-9c4e-dd04167f89ec", null, "Core Librarian", "CORE LIBRARIAN" },
                    { "fb6c3cb6-2ffa-40b4-b7a2-bb4aa59f9091", null, "Consultant", "CONSULTANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetNavigationMenuItem",
                columns: new[] { "Id", "Name", "ParentNavigationMenuItemId", "Route" },
                values: new object[,]
                {
                    { 16, "All Genres", 15, "/Books/Genres" },
                    { 17, "Add Genre", 15, "/Books/Genres/AddGenre" },
                    { 19, "All Languages", 18, "/Books/Languages" },
                    { 20, "Add Language", 18, "/Books/Languages/AddLanguage" },
                    { 22, "All Authors", 21, "/Books/Languages/AddLanguage" },
                    { 23, "Add Author", 21, "/Books/Authors/AddAuthor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02639985-77a9-4b02-954d-bc4b0cdad51f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45d8d084-207a-414f-8fcf-c465024c375a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "618cbc5a-0310-4a43-aa79-aa188d3183e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc8677c1-73c1-4109-9c4e-dd04167f89ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb6c3cb6-2ffa-40b4-b7a2-bb4aa59f9091");

            migrationBuilder.DeleteData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetNavigationMenuItem",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ec7d765-23cf-4924-98b4-59cb9ad48b29", null, "Librarian", "LIBRARIAN" },
                    { "5b82de6e-e0d0-4756-b832-13bed3063b0e", null, "Core Librarian", "CORE LIBRARIAN" },
                    { "cc920de8-6ecf-4c51-bb3e-33235c0359a1", null, "Human Resources Manager", "HUMAN RESOURCES MANAGER" },
                    { "dfe48fc2-c6c6-49e2-99b0-169c14face3b", null, "Consultant", "CONSULTANT" },
                    { "f8a5a82a-2f5c-4500-ab3f-f46cc4d1f0ca", null, "Operations Manager", "OPERATIONS MANAGER" }
                });
        }
    }
}
