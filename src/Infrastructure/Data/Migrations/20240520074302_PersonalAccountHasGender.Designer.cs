﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nika1337.Library.Infrastructure.Data;

#nullable disable

namespace Nika1337.Library.Infrastructure.Data.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20240520074302_PersonalAccountHasGender")]
    partial class PersonalAccountHasGender
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("BookGenre");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AccountCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biography")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAlive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MinimumAge")
                        .HasColumnType("int");

                    b.Property<int>("OriginalLanguageId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("OriginalReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("OriginalLanguageId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.BookCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookCopyCondition")
                        .HasColumnType("int");

                    b.Property<int>("BookEditionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookEditionId");

                    b.ToTable("BookCopies");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.BookEdition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PageCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int>("ShelfId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PublisherId");

                    b.HasIndex("ShelfId");

                    b.ToTable("BookEditions");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Bookshelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookshelves");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Checkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("BookCopyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CheckoutCloseTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CheckoutStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckoutTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SupposedReturnTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BookCopyId");

                    b.ToTable("Checkouts", t =>
                        {
                            t.HasCheckConstraint("CK_CloseMoreThanCheckout", "[CheckoutCloseTime] > [CheckoutTime]");

                            t.HasCheckConstraint("CK_CloseTimeWithStatus", "([CheckoutStatus] IS NULL AND [CheckoutCloseTime] IS NULL) OR ([CheckoutStatus] IS NOT NULL AND [CheckoutCloseTime] IS NOT NULL)");

                            t.HasCheckConstraint("CK_ReturnMoreThanCheckout", "[SupposedReturnTime] > [CheckoutTime]");
                        });
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("WebsiteAddress")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MaxCapacityOfPeople")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Shelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookshelfId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MaxCapacityOfBooks")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookshelfId");

                    b.ToTable("Shelves");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.CompanyAccount", b =>
                {
                    b.HasBaseType("Nika1337.Library.ApplicationCore.Entities.Account");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("WebsiteAddress")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.ToTable("CompanyAccounts");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.PersonalAccount", b =>
                {
                    b.HasBaseType("Nika1337.Library.ApplicationCore.Entities.Account");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToTable("PersonalAccounts");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Account", b =>
                {
                    b.OwnsOne("Nika1337.Library.ApplicationCore.Entities.ContactInformation", "ContactInformation", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .HasColumnType("int");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.HasKey("AccountId");

                            b1.ToTable("Accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId");

                            b1.OwnsOne("Nika1337.Library.ApplicationCore.Entities.Address", "Address", b2 =>
                                {
                                    b2.Property<int>("ContactInformationAccountId")
                                        .HasColumnType("int");

                                    b2.Property<string>("City")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("nvarchar(50)");

                                    b2.Property<string>("Country")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.Property<string>("PostalCode")
                                        .HasMaxLength(10)
                                        .HasColumnType("nvarchar(10)");

                                    b2.Property<string>("State")
                                        .HasMaxLength(50)
                                        .HasColumnType("nvarchar(50)");

                                    b2.Property<string>("Street")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.HasKey("ContactInformationAccountId");

                                    b2.ToTable("Accounts");

                                    b2.WithOwner()
                                        .HasForeignKey("ContactInformationAccountId");
                                });

                            b1.Navigation("Address")
                                .IsRequired();
                        });

                    b.Navigation("ContactInformation")
                        .IsRequired();
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Book", b =>
                {
                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.Language", "OriginalLanguage")
                        .WithMany()
                        .HasForeignKey("OriginalLanguageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OriginalLanguage");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.BookCopy", b =>
                {
                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.BookEdition", "BookEdition")
                        .WithMany("Copies")
                        .HasForeignKey("BookEditionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BookEdition");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.BookEdition", b =>
                {
                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.Book", "Book")
                        .WithMany("Editions")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.Publisher", "Publisher")
                        .WithMany("PublishedBooks")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.Shelf", "Shelf")
                        .WithMany("BookEditions")
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Language");

                    b.Navigation("Publisher");

                    b.Navigation("Shelf");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Bookshelf", b =>
                {
                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.Room", "Room")
                        .WithMany("Bookshelves")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Checkout", b =>
                {
                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.BookCopy", "BookCopy")
                        .WithMany()
                        .HasForeignKey("BookCopyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("BookCopy");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Publisher", b =>
                {
                    b.OwnsOne("Nika1337.Library.ApplicationCore.Entities.ContactInformation", "ContactInformation", b1 =>
                        {
                            b1.Property<int>("PublisherId")
                                .HasColumnType("int");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.HasKey("PublisherId");

                            b1.ToTable("Publishers");

                            b1.WithOwner()
                                .HasForeignKey("PublisherId");

                            b1.OwnsOne("Nika1337.Library.ApplicationCore.Entities.Address", "Address", b2 =>
                                {
                                    b2.Property<int>("ContactInformationPublisherId")
                                        .HasColumnType("int");

                                    b2.Property<string>("City")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("nvarchar(50)");

                                    b2.Property<string>("Country")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.Property<string>("PostalCode")
                                        .HasMaxLength(10)
                                        .HasColumnType("nvarchar(10)");

                                    b2.Property<string>("State")
                                        .HasMaxLength(50)
                                        .HasColumnType("nvarchar(50)");

                                    b2.Property<string>("Street")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.HasKey("ContactInformationPublisherId");

                                    b2.ToTable("Publishers");

                                    b2.WithOwner()
                                        .HasForeignKey("ContactInformationPublisherId");
                                });

                            b1.Navigation("Address")
                                .IsRequired();
                        });

                    b.Navigation("ContactInformation")
                        .IsRequired();
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Shelf", b =>
                {
                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.Bookshelf", "Bookshelf")
                        .WithMany("Shelves")
                        .HasForeignKey("BookshelfId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bookshelf");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.CompanyAccount", b =>
                {
                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.Account", null)
                        .WithOne()
                        .HasForeignKey("Nika1337.Library.ApplicationCore.Entities.CompanyAccount", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.PersonalAccount", b =>
                {
                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.Account", null)
                        .WithOne()
                        .HasForeignKey("Nika1337.Library.ApplicationCore.Entities.PersonalAccount", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Book", b =>
                {
                    b.Navigation("Editions");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.BookEdition", b =>
                {
                    b.Navigation("Copies");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Bookshelf", b =>
                {
                    b.Navigation("Shelves");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Publisher", b =>
                {
                    b.Navigation("PublishedBooks");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Room", b =>
                {
                    b.Navigation("Bookshelves");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.Shelf", b =>
                {
                    b.Navigation("BookEditions");
                });
#pragma warning restore 612, 618
        }
    }
}
