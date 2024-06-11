using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nika1337.Library.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class RestrictRoleDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15d8f808-b8e8-4b00-9300-43476da970fb", null, "Core Librarian", "CORE LIBRARIAN" },
                    { "233ff12e-dfb5-4864-ab35-7ce398443c7b", null, "Operations Manager", "OPERATIONS MANAGER" },
                    { "3bd3b1a4-3f0d-49b2-afcc-a24b034034ed", null, "Librarian", "LIBRARIAN" },
                    { "7eb8eed4-543d-4eef-9692-aaab0780d714", null, "Human Resources Manager", "HUMAN RESOURCES MANAGER" },
                    { "e19d6a57-7b78-4095-bb13-a9ee9c239b79", null, "Consultant", "CONSULTANT" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15d8f808-b8e8-4b00-9300-43476da970fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "233ff12e-dfb5-4864-ab35-7ce398443c7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bd3b1a4-3f0d-49b2-afcc-a24b034034ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7eb8eed4-543d-4eef-9692-aaab0780d714");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e19d6a57-7b78-4095-bb13-a9ee9c239b79");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
