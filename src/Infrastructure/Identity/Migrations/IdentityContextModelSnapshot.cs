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

                    b.Property<int>("NavigationMenuItemsId")
                        .HasColumnType("int");

                    b.HasKey("IdentityEmployeeRoleId", "NavigationMenuItemsId");

                    b.HasIndex("NavigationMenuItemsId");

                    b.ToTable("IdentityEmployeeRoleNavigationMenuItem");

                    b.HasData(
                        new
                        {
                            IdentityEmployeeRoleId = "ded207c7-7e7f-44b4-8b4a-a8681067c398",
                            NavigationMenuItemsId = 1
                        },
                        new
                        {
                            IdentityEmployeeRoleId = "ded207c7-7e7f-44b4-8b4a-a8681067c398",
                            NavigationMenuItemsId = 2
                        },
                        new
                        {
                            IdentityEmployeeRoleId = "ded207c7-7e7f-44b4-8b4a-a8681067c398",
                            NavigationMenuItemsId = 3
                        });
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
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
                        .IsRequired()
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
                            Name = "Employees",
                            Route = "/EmployeeManagement/AllEmployees"
                        },
                        new
                        {
                            Id = 2,
                            Name = "All Employees",
                            ParentNavigationMenuItemId = 1,
                            Route = "/EmployeeManagement/AllEmployees"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Register Employee",
                            ParentNavigationMenuItemId = 1,
                            Route = "/EmployeeManagement/RegisterEmployee"
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
                            Id = "ded207c7-7e7f-44b4-8b4a-a8681067c398",
                            Name = "Human Resources Manager",
                            NormalizedName = "HUMAN RESOURCES MANAGER"
                        },
                        new
                        {
                            Id = "4b07c235-81f8-47ee-8100-cfb626cb0848",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "8983f885-d39e-4ac0-a4d5-576f9b4adfc8",
                            Name = "Librarian",
                            NormalizedName = "LIBRARIAN"
                        },
                        new
                        {
                            Id = "f20a11b7-9fb9-4964-993e-6304353c885d",
                            Name = "Core Librarian",
                            NormalizedName = "CORE LIBRARIAN"
                        },
                        new
                        {
                            Id = "07b9c56b-082d-44c7-94f5-8239d965d681",
                            Name = "Consultant",
                            NormalizedName = "CONSULTANT"
                        });
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
                        .HasForeignKey("NavigationMenuItemsId")
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Nika1337.Library.Infrastructure.Identity.Entities.IdentityEmployeeRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("Nika1337.Library.ApplicationCore.Entities.NavigationMenuItem", b =>
                {
                    b.Navigation("ChildNavigationMenuItems");
                });
#pragma warning restore 612, 618
        }
    }
}
