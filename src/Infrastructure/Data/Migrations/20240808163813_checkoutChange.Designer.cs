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
    [Migration("20240808163813_checkoutChange")]
    partial class checkoutChange
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

            modelBuilder.Entity("BookCopyBookEditionCopiesAuditEntry", b =>
                {
                    b.Property<int>("BookCopiesId")
                        .HasColumnType("int");

                    b.Property<int>("BookEditionCopiesAuditEntryId")
                        .HasColumnType("int");

                    b.HasKey("BookCopiesId", "BookEditionCopiesAuditEntryId");

                    b.HasIndex("BookEditionCopiesAuditEntryId");

                    b.ToTable("BookCopyBookEditionCopiesAuditEntry");
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

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Account", b =>
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

                    b.Property<string>("CustomerIdentification")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.AuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Changes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedRowId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAlive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<byte?>("MinimumAge")
                        .HasColumnType("tinyint");

                    b.Property<int>("OriginalLanguageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OriginalReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .IsRequired()
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

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.BookCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookEditionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookEditionId");

                    b.ToTable("BookCopies");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.BookCopyCheckout", b =>
                {
                    b.Property<int>("CheckoutId")
                        .HasColumnType("int");

                    b.Property<int>("BookCopyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BookCopyCheckoutCloseTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BookCopyCheckoutStatus")
                        .HasColumnType("int");

                    b.HasKey("CheckoutId", "BookCopyId");

                    b.HasIndex("BookCopyId");

                    b.ToTable("BookCopyCheckout", t =>
                        {
                            t.HasCheckConstraint("CK_CloseTimeWithStatus", "([BookCopyCheckoutStatus] IS NULL AND [BookCopyCheckoutCloseTime] IS NULL) OR ([BookCopyCheckoutStatus] IS NOT NULL AND [BookCopyCheckoutCloseTime] IS NOT NULL)");
                        });
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.BookEdition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int?>("PageCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PublisherId");

                    b.HasIndex("RoomId");

                    b.ToTable("BookEditions");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.BookEditionCopiesAuditEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Action")
                        .HasColumnType("int");

                    b.Property<int>("BookEditionId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookEditionId");

                    b.ToTable("BookEditionCopiesAuditEntry");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Checkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("BookEditionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckoutTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SupposedReturnTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BookEditionId");

                    b.ToTable("Checkouts", t =>
                        {
                            t.HasCheckConstraint("CK_ReturnMoreThanCheckout", "[SupposedReturnTime] > [CheckoutTime]");
                        });
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.EmailTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BriefDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FromEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Separator")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("EmailTemplates");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedDate")
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

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int?>("MaxCapacityOfPeople")
                        .HasColumnType("int");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("Nika1337.Library.Domain.Entities.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nika1337.Library.Domain.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookCopyBookEditionCopiesAuditEntry", b =>
                {
                    b.HasOne("Nika1337.Library.Domain.Entities.BookCopy", null)
                        .WithMany()
                        .HasForeignKey("BookCopiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nika1337.Library.Domain.Entities.BookEditionCopiesAuditEntry", null)
                        .WithMany()
                        .HasForeignKey("BookEditionCopiesAuditEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.HasOne("Nika1337.Library.Domain.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nika1337.Library.Domain.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Account", b =>
                {
                    b.OwnsOne("Nika1337.Library.Domain.Entities.ContactInformation", "ContactInformation", b1 =>
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

                            b1.OwnsOne("Nika1337.Library.Domain.Entities.Address", "Address", b2 =>
                                {
                                    b2.Property<int>("ContactInformationAccountId")
                                        .HasColumnType("int");

                                    b2.Property<string>("City")
                                        .HasMaxLength(50)
                                        .HasColumnType("nvarchar(50)");

                                    b2.Property<string>("Country")
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.Property<string>("PostalCode")
                                        .HasMaxLength(10)
                                        .HasColumnType("nvarchar(10)");

                                    b2.Property<string>("State")
                                        .HasMaxLength(50)
                                        .HasColumnType("nvarchar(50)");

                                    b2.Property<string>("Street")
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

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Book", b =>
                {
                    b.HasOne("Nika1337.Library.Domain.Entities.Language", "OriginalLanguage")
                        .WithMany()
                        .HasForeignKey("OriginalLanguageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OriginalLanguage");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.BookCopy", b =>
                {
                    b.HasOne("Nika1337.Library.Domain.Entities.BookEdition", "BookEdition")
                        .WithMany("Copies")
                        .HasForeignKey("BookEditionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BookEdition");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.BookCopyCheckout", b =>
                {
                    b.HasOne("Nika1337.Library.Domain.Entities.BookCopy", "BookCopy")
                        .WithMany("BookCopyCheckouts")
                        .HasForeignKey("BookCopyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Nika1337.Library.Domain.Entities.Checkout", "Checkout")
                        .WithMany("BookCopyCheckouts")
                        .HasForeignKey("CheckoutId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BookCopy");

                    b.Navigation("Checkout");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.BookEdition", b =>
                {
                    b.HasOne("Nika1337.Library.Domain.Entities.Book", "Book")
                        .WithMany("Editions")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Nika1337.Library.Domain.Entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Nika1337.Library.Domain.Entities.Publisher", "Publisher")
                        .WithMany("PublishedBookEditions")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Nika1337.Library.Domain.Entities.Room", "Room")
                        .WithMany("BookEditions")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Language");

                    b.Navigation("Publisher");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.BookEditionCopiesAuditEntry", b =>
                {
                    b.HasOne("Nika1337.Library.Domain.Entities.BookEdition", "BookEdition")
                        .WithMany("Audit")
                        .HasForeignKey("BookEditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookEdition");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Checkout", b =>
                {
                    b.HasOne("Nika1337.Library.Domain.Entities.Account", "Account")
                        .WithMany("Checkouts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Nika1337.Library.Domain.Entities.BookEdition", "BookEdition")
                        .WithMany()
                        .HasForeignKey("BookEditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("BookEdition");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Publisher", b =>
                {
                    b.OwnsOne("Nika1337.Library.Domain.Entities.ContactInformation", "ContactInformation", b1 =>
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

                            b1.OwnsOne("Nika1337.Library.Domain.Entities.Address", "Address", b2 =>
                                {
                                    b2.Property<int>("ContactInformationPublisherId")
                                        .HasColumnType("int");

                                    b2.Property<string>("City")
                                        .HasMaxLength(50)
                                        .HasColumnType("nvarchar(50)");

                                    b2.Property<string>("Country")
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.Property<string>("PostalCode")
                                        .HasMaxLength(10)
                                        .HasColumnType("nvarchar(10)");

                                    b2.Property<string>("State")
                                        .HasMaxLength(50)
                                        .HasColumnType("nvarchar(50)");

                                    b2.Property<string>("Street")
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

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Account", b =>
                {
                    b.Navigation("Checkouts");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Book", b =>
                {
                    b.Navigation("Editions");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.BookCopy", b =>
                {
                    b.Navigation("BookCopyCheckouts");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.BookEdition", b =>
                {
                    b.Navigation("Audit");

                    b.Navigation("Copies");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Checkout", b =>
                {
                    b.Navigation("BookCopyCheckouts");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Publisher", b =>
                {
                    b.Navigation("PublishedBookEditions");
                });

            modelBuilder.Entity("Nika1337.Library.Domain.Entities.Room", b =>
                {
                    b.Navigation("BookEditions");
                });
#pragma warning restore 612, 618
        }
    }
}
