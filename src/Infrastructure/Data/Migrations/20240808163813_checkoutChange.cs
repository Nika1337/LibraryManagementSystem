using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nika1337.Library.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class checkoutChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookEditionId",
                table: "Checkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_BookEditionId",
                table: "Checkouts",
                column: "BookEditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_BookEditions_BookEditionId",
                table: "Checkouts",
                column: "BookEditionId",
                principalTable: "BookEditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_BookEditions_BookEditionId",
                table: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_BookEditionId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "BookEditionId",
                table: "Checkouts");
        }
    }
}
