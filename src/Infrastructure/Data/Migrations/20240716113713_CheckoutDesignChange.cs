using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nika1337.Library.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CheckoutDesignChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_BookCopies_BookCopyId",
                table: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_BookCopyId",
                table: "Checkouts");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CloseMoreThanCheckout",
                table: "Checkouts");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CloseTimeWithStatus",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "BookCopyId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "CheckoutCloseTime",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "CheckoutStatus",
                table: "Checkouts");

            migrationBuilder.CreateTable(
                name: "BookCopyCheckout",
                columns: table => new
                {
                    CheckoutId = table.Column<int>(type: "int", nullable: false),
                    BookCopyId = table.Column<int>(type: "int", nullable: false),
                    BookCopyCheckoutStatus = table.Column<int>(type: "int", nullable: false),
                    BookCopyCheckoutCloseTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopyCheckout", x => new { x.CheckoutId, x.BookCopyId });
                    table.CheckConstraint("CK_CloseTimeWithStatus", "([BookCopyCheckoutStatus] IS NULL AND [BookCopyCheckoutCloseTime] IS NULL) OR ([BookCopyCheckoutStatus] IS NOT NULL AND [BookCopyCheckoutCloseTime] IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_BookCopyCheckout_BookCopies_BookCopyId",
                        column: x => x.BookCopyId,
                        principalTable: "BookCopies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookCopyCheckout_Checkouts_CheckoutId",
                        column: x => x.CheckoutId,
                        principalTable: "Checkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCopyCheckout_BookCopyId",
                table: "BookCopyCheckout",
                column: "BookCopyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCopyCheckout");

            migrationBuilder.AddColumn<int>(
                name: "BookCopyId",
                table: "Checkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckoutCloseTime",
                table: "Checkouts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CheckoutStatus",
                table: "Checkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_BookCopyId",
                table: "Checkouts",
                column: "BookCopyId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_CloseMoreThanCheckout",
                table: "Checkouts",
                sql: "[CheckoutCloseTime] > [CheckoutTime]");

            migrationBuilder.AddCheckConstraint(
                name: "CK_CloseTimeWithStatus",
                table: "Checkouts",
                sql: "([CheckoutStatus] IS NULL AND [CheckoutCloseTime] IS NULL) OR ([CheckoutStatus] IS NOT NULL AND [CheckoutCloseTime] IS NOT NULL)");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_BookCopies_BookCopyId",
                table: "Checkouts",
                column: "BookCopyId",
                principalTable: "BookCopies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
