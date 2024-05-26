using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nika1337.Library.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationForLibrary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    AccountCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactInformation_Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContactInformation_PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContactInformation_Address_Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactInformation_Address_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactInformation_Address_State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactInformation_Address_Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactInformation_Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAlive = table.Column<bool>(type: "bit", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactInformation_Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContactInformation_PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContactInformation_Address_Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactInformation_Address_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactInformation_Address_State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactInformation_Address_Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactInformation_Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebsiteAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    MaxCapacityOfPeople = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    WebsiteAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyAccounts_Accounts_Id",
                        column: x => x.Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalAccounts_Accounts_Id",
                        column: x => x.Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    OriginalReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MinimumAge = table.Column<int>(type: "int", nullable: true),
                    OriginalLanguageId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Languages_OriginalLanguageId",
                        column: x => x.OriginalLanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookshelves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookshelves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookshelves_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => new { x.BooksId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_BookGenre_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenre_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shelves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookshelfId = table.Column<int>(type: "int", nullable: false),
                    MaxCapacityOfBooks = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shelves_Bookshelves_BookshelfId",
                        column: x => x.BookshelfId,
                        principalTable: "Bookshelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookEditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Isbn = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: true),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    ShelfId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookEditions_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookEditions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookEditions_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookEditions_Shelves_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookCopies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookEditionId = table.Column<int>(type: "int", nullable: false),
                    BookCopyCondition = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookCopies_BookEditions_BookEditionId",
                        column: x => x.BookEditionId,
                        principalTable: "BookEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    BookCopyId = table.Column<int>(type: "int", nullable: false),
                    CheckoutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupposedReturnTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckoutCloseTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckoutStatus = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.Id);
                    table.CheckConstraint("CK_CloseMoreThanCheckout", "[CheckoutCloseTime] > [CheckoutTime]");
                    table.CheckConstraint("CK_CloseTimeWithStatus", "([CheckoutStatus] IS NULL AND [CheckoutCloseTime] IS NULL) OR ([CheckoutStatus] IS NOT NULL AND [CheckoutCloseTime] IS NOT NULL)");
                    table.CheckConstraint("CK_ReturnMoreThanCheckout", "[SupposedReturnTime] > [CheckoutTime]");
                    table.ForeignKey(
                        name: "FK_Checkouts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkouts_BookCopies_BookCopyId",
                        column: x => x.BookCopyId,
                        principalTable: "BookCopies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_BookEditionId",
                table: "BookCopies",
                column: "BookEditionId");

            migrationBuilder.CreateIndex(
                name: "IX_BookEditions_BookId",
                table: "BookEditions",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookEditions_LanguageId",
                table: "BookEditions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_BookEditions_PublisherId",
                table: "BookEditions",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_BookEditions_ShelfId",
                table: "BookEditions",
                column: "ShelfId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenresId",
                table: "BookGenre",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_OriginalLanguageId",
                table: "Books",
                column: "OriginalLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookshelves_RoomId",
                table: "Bookshelves",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_AccountId",
                table: "Checkouts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_BookCopyId",
                table: "Checkouts",
                column: "BookCopyId");

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_BookshelfId",
                table: "Shelves",
                column: "BookshelfId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "BookGenre");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "CompanyAccounts");

            migrationBuilder.DropTable(
                name: "PersonalAccounts");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "BookCopies");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "BookEditions");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Shelves");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Bookshelves");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
