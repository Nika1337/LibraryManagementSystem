﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nika1337.Library.Infrastructure.Identity;

#nullable disable

namespace Nika1337.Library.Infrastructure.Identity.Migrations
{
    [DbContext(typeof(IdentityContext))]
    partial class IdentityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IdentityEmployeeRoleNavigationMenuItem", b =>
                {
                    b.Property<string>("IdentityEmployeeRoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PermittedNavigationMenuItemsId")
                        .HasColumnType("int");

                    b.HasKey("IdentityEmployeeRoleId", "PermittedNavigationMenuItemsId");

                    b.HasIndex("PermittedNavigationMenuItemsId");

                    b.ToTable("IdentityEmployeeRoleNavigationMenuItem");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.AuditLog", b =>
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

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.NavigationMenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<int?>("ParentNavigationMenuItemId")
                        .HasColumnType("int");

                    b.Property<string>("Route")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentNavigationMenuItemId");

                    b.ToTable("AspNetNavigationMenuItem", null, t =>
                        {
                            t.HasCheckConstraint("CK_NavigationMenuItem_ParentId", "Id <> ParentNavigationMenuItemId");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Employees"
                        },
                        new
                        {
                            Id = 2,
                            Name = "All Employees",
                            ParentNavigationMenuItemId = 1,
                            Route = "/Employees/"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Register Employee",
                            ParentNavigationMenuItemId = 1,
                            Route = "/Employees/RegisterEmployee"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Operations"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Email Templates",
                            ParentNavigationMenuItemId = 4,
                            Route = "/EmailTemplates"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Books"
                        },
                        new
                        {
                            Id = 7,
                            Name = "All Books",
                            ParentNavigationMenuItemId = 6,
                            Route = "/Books"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Add Book",
                            ParentNavigationMenuItemId = 6,
                            Route = "/Books/AddBook"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Book Editions",
                            ParentNavigationMenuItemId = 6
                        },
                        new
                        {
                            Id = 10,
                            Name = "All Book Editions",
                            ParentNavigationMenuItemId = 9,
                            Route = "/Books/BookEditions"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Add Book Edition",
                            ParentNavigationMenuItemId = 9,
                            Route = "/Books/BookEditions/AddBookEdition"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Book Copies",
                            ParentNavigationMenuItemId = 9
                        },
                        new
                        {
                            Id = 13,
                            Name = "All Book Copies",
                            ParentNavigationMenuItemId = 12,
                            Route = "/Books/BookEditions/BookCopies"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Add Book Copy",
                            ParentNavigationMenuItemId = 12,
                            Route = "/Books/BookEditions/BookCopies/AddBookCopy"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Genres",
                            ParentNavigationMenuItemId = 6
                        },
                        new
                        {
                            Id = 16,
                            Name = "All Genres",
                            ParentNavigationMenuItemId = 15,
                            Route = "/Books/Genres"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Add Genre",
                            ParentNavigationMenuItemId = 15,
                            Route = "/Books/Genres/AddGenre"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Languages",
                            ParentNavigationMenuItemId = 6
                        },
                        new
                        {
                            Id = 19,
                            Name = "All Languages",
                            ParentNavigationMenuItemId = 18,
                            Route = "/Books/Languages"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Add Language",
                            ParentNavigationMenuItemId = 18,
                            Route = "/Books/Languages/AddLanguage"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Author"
                        },
                        new
                        {
                            Id = 22,
                            Name = "All Authors",
                            ParentNavigationMenuItemId = 21,
                            Route = "/Books/Languages/AddLanguage"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Add Author",
                            ParentNavigationMenuItemId = 21,
                            Route = "/Books/Authors/AddAuthor"
                        });
                });

            modelBuilder.Entity("Nika1337.Library.Infrastructure.Identity.Entities.IdentityEmployee", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TerminationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", null, t =>
                        {
                            t.HasCheckConstraint("CK_Employee_AgeRequirement", "DATEDIFF(year, DateOfBirth, StartDate) >= 18");

                            t.HasCheckConstraint("CK_Employee_TerminationDate", "TerminationDate IS NULL OR TerminationDate >= StartDate");
                        });
                });

            modelBuilder.Entity("Nika1337.Library.Infrastructure.Identity.Entities.IdentityEmployeeRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "7eb8eed4-543d-4eef-9692-aaab0780d714",
                            Name = "Human Resources Manager",
                            NormalizedName = "HUMAN RESOURCES MANAGER"
                        },
                        new
                        {
                            Id = "233ff12e-dfb5-4864-ab35-7ce398443c7b",
                            Name = "Operations Manager",
                            NormalizedName = "OPERATIONS MANAGER"
                        },
                        new
                        {
                            Id = "3bd3b1a4-3f0d-49b2-afcc-a24b034034ed",
                            Name = "Librarian",
                            NormalizedName = "LIBRARIAN"
                        },
                        new
                        {
                            Id = "15d8f808-b8e8-4b00-9300-43476da970fb",
                            Name = "Core Librarian",
                            NormalizedName = "CORE LIBRARIAN"
                        },
                        new
                        {
                            Id = "e19d6a57-7b78-4095-bb13-a9ee9c239b79",
                            Name = "Consultant",
                            NormalizedName = "CONSULTANT"
                        });
                });

            modelBuilder.Entity("Nika1337.Library.Infrastructure.Identity.Entities.IdentityEmployeeRoleJunction", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("IdentityEmployeeRoleNavigationMenuItem", b =>
                {
                    b.HasOne("Nika1337.Library.Infrastructure.Identity.Entities.IdentityEmployeeRole", null)
                        .WithMany()
                        .HasForeignKey("IdentityEmployeeRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.NavigationMenuItem", null)
                        .WithMany()
                        .HasForeignKey("PermittedNavigationMenuItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Nika1337.Library.Infrastructure.Identity.Entities.IdentityEmployeeRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Nika1337.Library.Infrastructure.Identity.Entities.IdentityEmployee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Nika1337.Library.Infrastructure.Identity.Entities.IdentityEmployee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Nika1337.Library.Infrastructure.Identity.Entities.IdentityEmployee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.NavigationMenuItem", b =>
                {
                    b.HasOne("Nika1337.Library.ApplicationCore.Entities.NavigationMenuItem", null)
                        .WithMany("ChildNavigationMenuItems")
                        .HasForeignKey("ParentNavigationMenuItemId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Nika1337.Library.Infrastructure.Identity.Entities.IdentityEmployee", b =>
                {
                    b.OwnsOne("Nika1337.Library.ApplicationCore.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<string>("IdentityEmployeeId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("City")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Country")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("PostalCode")
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("State")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Street")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("IdentityEmployeeId");

                            b1.ToTable("AspNetUsers");

                            b1.WithOwner()
                                .HasForeignKey("IdentityEmployeeId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Nika1337.Library.Infrastructure.Identity.Entities.IdentityEmployeeRoleJunction", b =>
                {
                    b.HasOne("Nika1337.Library.Infrastructure.Identity.Entities.IdentityEmployeeRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Nika1337.Library.Infrastructure.Identity.Entities.IdentityEmployee", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.NavigationMenuItem", b =>
                {
                    b.Navigation("ChildNavigationMenuItems");
                });

            modelBuilder.Entity("Nika1337.Library.Infrastructure.Identity.Entities.IdentityEmployee", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
