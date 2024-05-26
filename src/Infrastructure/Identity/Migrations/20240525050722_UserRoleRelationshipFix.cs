using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nika1337.Library.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleRelationshipFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_IdentityEmployeeId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_IdentityEmployeeId",
                table: "AspNetRoles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a38e59a-014b-4f03-a2a8-e5b8181d2893");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60b0f29f-2f3c-4902-9b7c-6506aa9d3169");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5d2ebe0-d4a5-4983-a8f9-79d747ac0fcb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b86de87a-3947-4f88-9603-dfc2a2ead5ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f58de269-af4e-48e9-84ca-dec34f20cad1");

            migrationBuilder.DropColumn(
                name: "IdentityEmployeeId",
                table: "AspNetRoles");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "IdentityEmployeeId",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IdentityEmployeeId", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a38e59a-014b-4f03-a2a8-e5b8181d2893", null, null, "Administrator", "ADMINISTRATOR" },
                    { "60b0f29f-2f3c-4902-9b7c-6506aa9d3169", null, null, "Librarian", "LIBRARIAN" },
                    { "a5d2ebe0-d4a5-4983-a8f9-79d747ac0fcb", null, null, "Human Resources Manager", "HRMANAGER" },
                    { "b86de87a-3947-4f88-9603-dfc2a2ead5ce", null, null, "Consultant", "CONSULTANT" },
                    { "f58de269-af4e-48e9-84ca-dec34f20cad1", null, null, "Core Librarian", "CORELIBRARIAN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_IdentityEmployeeId",
                table: "AspNetRoles",
                column: "IdentityEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_IdentityEmployeeId",
                table: "AspNetRoles",
                column: "IdentityEmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
