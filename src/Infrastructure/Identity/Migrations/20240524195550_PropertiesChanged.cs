using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nika1337.Library.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class PropertiesChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetNavigationMenuItem_AspNetNavigationMenuItem_ParentNavigationMenuItemId",
                table: "AspNetNavigationMenuItem");

            migrationBuilder.DropTable(
                name: "EmployeeRoleNavigationMenuItem");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f6b41ad-18dd-46dd-ba6c-7e4f3fc8a148");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d0aa018-74f4-44de-abed-dfebc3c392e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5915c50a-14c8-45e3-8670-23de10a2fbee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f492ba2-94e7-4929-adf0-54c3743add76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e30323c8-6c43-4848-be80-60283e171916");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Address_Street",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address_Country",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address_City",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityEmployeeId",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityEmployeeRoleNavigationMenuItem",
                columns: table => new
                {
                    IdentityEmployeeRoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NavigationMenuItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityEmployeeRoleNavigationMenuItem", x => new { x.IdentityEmployeeRoleId, x.NavigationMenuItemsId });
                    table.ForeignKey(
                        name: "FK_IdentityEmployeeRoleNavigationMenuItem_AspNetNavigationMenuItem_NavigationMenuItemsId",
                        column: x => x.NavigationMenuItemsId,
                        principalTable: "AspNetNavigationMenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityEmployeeRoleNavigationMenuItem_AspNetRoles_IdentityEmployeeRoleId",
                        column: x => x.IdentityEmployeeRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_IdentityEmployeeRoleNavigationMenuItem_NavigationMenuItemsId",
                table: "IdentityEmployeeRoleNavigationMenuItem",
                column: "NavigationMenuItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetNavigationMenuItem_AspNetNavigationMenuItem_ParentNavigationMenuItemId",
                table: "AspNetNavigationMenuItem",
                column: "ParentNavigationMenuItemId",
                principalTable: "AspNetNavigationMenuItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_IdentityEmployeeId",
                table: "AspNetRoles",
                column: "IdentityEmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetNavigationMenuItem_AspNetNavigationMenuItem_ParentNavigationMenuItemId",
                table: "AspNetNavigationMenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_IdentityEmployeeId",
                table: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "IdentityEmployeeRoleNavigationMenuItem");

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
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdentityEmployeeId",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_Street",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_Country",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_City",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeRoleNavigationMenuItem",
                columns: table => new
                {
                    EmployeeRoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NavigationMenuItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoleNavigationMenuItem", x => new { x.EmployeeRoleId, x.NavigationMenuItemsId });
                    table.ForeignKey(
                        name: "FK_EmployeeRoleNavigationMenuItem_AspNetNavigationMenuItem_NavigationMenuItemsId",
                        column: x => x.NavigationMenuItemsId,
                        principalTable: "AspNetNavigationMenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRoleNavigationMenuItem_AspNetRoles_EmployeeRoleId",
                        column: x => x.EmployeeRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f6b41ad-18dd-46dd-ba6c-7e4f3fc8a148", null, "Consultant", "CONSULTANT" },
                    { "3d0aa018-74f4-44de-abed-dfebc3c392e4", null, "Administrator", "ADMINISTRATOR" },
                    { "5915c50a-14c8-45e3-8670-23de10a2fbee", null, "Librarian", "LIBRARIAN" },
                    { "7f492ba2-94e7-4929-adf0-54c3743add76", null, "Core Librarian", "CORELIBRARIAN" },
                    { "e30323c8-6c43-4848-be80-60283e171916", null, "Human Resources Manager", "HRMANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoleNavigationMenuItem_NavigationMenuItemsId",
                table: "EmployeeRoleNavigationMenuItem",
                column: "NavigationMenuItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetNavigationMenuItem_AspNetNavigationMenuItem_ParentNavigationMenuItemId",
                table: "AspNetNavigationMenuItem",
                column: "ParentNavigationMenuItemId",
                principalTable: "AspNetNavigationMenuItem",
                principalColumn: "Id");
        }
    }
}
