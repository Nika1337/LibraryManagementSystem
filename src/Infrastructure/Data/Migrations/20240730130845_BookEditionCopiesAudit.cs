using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nika1337.Library.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class BookEditionCopiesAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookEditionCopiesAuditEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookEditionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEditionCopiesAuditEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookEditionCopiesAuditEntry_BookEditions_BookEditionId",
                        column: x => x.BookEditionId,
                        principalTable: "BookEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCopyBookEditionCopiesAuditEntry",
                columns: table => new
                {
                    BookCopiesId = table.Column<int>(type: "int", nullable: false),
                    BookEditionCopiesAuditEntryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopyBookEditionCopiesAuditEntry", x => new { x.BookCopiesId, x.BookEditionCopiesAuditEntryId });
                    table.ForeignKey(
                        name: "FK_BookCopyBookEditionCopiesAuditEntry_BookCopies_BookCopiesId",
                        column: x => x.BookCopiesId,
                        principalTable: "BookCopies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCopyBookEditionCopiesAuditEntry_BookEditionCopiesAuditEntry_BookEditionCopiesAuditEntryId",
                        column: x => x.BookEditionCopiesAuditEntryId,
                        principalTable: "BookEditionCopiesAuditEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCopyBookEditionCopiesAuditEntry_BookEditionCopiesAuditEntryId",
                table: "BookCopyBookEditionCopiesAuditEntry",
                column: "BookEditionCopiesAuditEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookEditionCopiesAuditEntry_BookEditionId",
                table: "BookEditionCopiesAuditEntry",
                column: "BookEditionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCopyBookEditionCopiesAuditEntry");

            migrationBuilder.DropTable(
                name: "BookEditionCopiesAuditEntry");
        }
    }
}
