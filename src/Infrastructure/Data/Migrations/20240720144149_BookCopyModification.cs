using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nika1337.Library.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class BookCopyModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookCopyCondition",
                table: "BookCopies");

            migrationBuilder.AlterColumn<int>(
                name: "BookCopyCheckoutStatus",
                table: "BookCopyCheckout",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BookCopyCheckoutStatus",
                table: "BookCopyCheckout",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookCopyCondition",
                table: "BookCopies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
