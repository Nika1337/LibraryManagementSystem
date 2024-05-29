using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nika1337.Library.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class emailTemplateBaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "ArchivedDate",
                table: "EmailTemplates",
                newName: "DeletedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "EmailTemplates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "EmailTemplates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "EmailTemplates");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "EmailTemplates");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "EmailTemplates",
                newName: "ArchivedDate");
        }
    }
}
