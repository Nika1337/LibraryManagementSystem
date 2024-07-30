using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nika1337.Library.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class BookCopyAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookCopyAuditEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopyAuditEntry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookCopyBookCopyAuditEntry",
                columns: table => new
                {
                    BookCopyAuditId = table.Column<int>(type: "int", nullable: false),
                    ModelsChangedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopyBookCopyAuditEntry", x => new { x.BookCopyAuditId, x.ModelsChangedId });
                    table.ForeignKey(
                        name: "FK_BookCopyBookCopyAuditEntry_BookCopies_ModelsChangedId",
                        column: x => x.ModelsChangedId,
                        principalTable: "BookCopies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCopyBookCopyAuditEntry_BookCopyAuditEntry_BookCopyAuditId",
                        column: x => x.BookCopyAuditId,
                        principalTable: "BookCopyAuditEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCopyBookCopyAuditEntry_ModelsChangedId",
                table: "BookCopyBookCopyAuditEntry",
                column: "ModelsChangedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCopyBookCopyAuditEntry");

            migrationBuilder.DropTable(
                name: "BookCopyAuditEntry");
        }
    }
}
