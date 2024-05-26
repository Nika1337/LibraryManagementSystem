using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nika1337.Library.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleRelationshipFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityEmployeeIdentityEmployeeRole");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28e6c352-d3b9-45fd-9959-c3e66e910b99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b212769-6fc4-46d4-991a-269fb5520fdc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fb8a14e-93e6-4d97-955b-e8a93ac7340a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c2c118c-c986-4eac-a848-2bcc04880378");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d7eb389-5639-48f9-a2bd-98335d1c83d5");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "IdentityEmployeeIdentityEmployeeRole",
                columns: table => new
                {
                    IdentityEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RolesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityEmployeeIdentityEmployeeRole", x => new { x.IdentityEmployeeId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_IdentityEmployeeIdentityEmployeeRole_AspNetRoles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityEmployeeIdentityEmployeeRole_AspNetUsers_IdentityEmployeeId",
                        column: x => x.IdentityEmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28e6c352-d3b9-45fd-9959-c3e66e910b99", null, "Librarian", "LIBRARIAN" },
                    { "2b212769-6fc4-46d4-991a-269fb5520fdc", null, "Human Resources Manager", "HRMANAGER" },
                    { "3fb8a14e-93e6-4d97-955b-e8a93ac7340a", null, "Consultant", "CONSULTANT" },
                    { "4c2c118c-c986-4eac-a848-2bcc04880378", null, "Core Librarian", "CORELIBRARIAN" },
                    { "4d7eb389-5639-48f9-a2bd-98335d1c83d5", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityEmployeeIdentityEmployeeRole_RolesId",
                table: "IdentityEmployeeIdentityEmployeeRole",
                column: "RolesId");
        }
    }
}
