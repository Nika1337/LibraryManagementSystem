﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.Infrastructure.Identity.Entities;
using System.Collections.Generic;

namespace Nika1337.Library.Infrastructure.Identity.Config;

internal class NavigationMenuItemConfiguration : IEntityTypeConfiguration<NavigationMenuItem>
{
    public void Configure(EntityTypeBuilder<NavigationMenuItem> builder)
    {

        builder
            .ToTable(builder =>
                builder.HasCheckConstraint("CK_NavigationMenuItem_ParentId", "Id <> ParentNavigationMenuItemId")
            )
            .ToTable("AspNetNavigationMenuItem");

        builder
            .Property(nmi => nmi.Name)
            .HasMaxLength(30);

        builder
            .Property(nmi => nmi.Name)
            .HasMaxLength(75);

        builder
            .HasMany(pnmi => pnmi.ChildNavigationMenuItems)
            .WithOne()
            .HasForeignKey(cnmi => cnmi.ParentNavigationMenuItemId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.HasMany<IdentityEmployeeRole>()
            .WithMany(role => role.PermittedNavigationMenuItems);

        SeedData(builder);
    }

    private void SeedData(EntityTypeBuilder<NavigationMenuItem> builder)
    {
        var employeesRoute = new List<NavigationMenuItem> {
            new() {
                Id = 1,
                Name = "Employees"
            },
            new()
            {
                Id = 2,
                Name = "All Employees",
                Route = "/Employees/",
                ParentNavigationMenuItemId = 1
            },
            new()
            {
                Id = 3,
                Name = "Register Employee",
                Route = "/Employees/RegisterEmployee",
                ParentNavigationMenuItemId = 1
            },
            new()
            {
                Id = 4,
                Name = "Operations",
            },
            new()
            {
                Id = 5,
                Name = "Email Templates",
                Route = "/EmailTemplates",
                ParentNavigationMenuItemId = 4
            },
            new()
            {
                Id = 6,
                Name = "Books",
            },
            new()
            {
                Id = 7,
                Name = "All Books",
                Route = "/Books",
                ParentNavigationMenuItemId = 6
            },
            new()
            {
                Id = 8,
                Name = "Add Book",
                Route = "/Books/AddBook",
                ParentNavigationMenuItemId = 6
            },
            new()
            {
                Id = 9,
                Name = "Book Editions",
                ParentNavigationMenuItemId = 6
            },
            new()
            {
                Id = 10,
                Name = "All Book Editions",
                Route = "/Books/BookEditions",
                ParentNavigationMenuItemId = 9
            },
            new()
            {
                Id = 11,
                Name = "Add Book Edition",
                Route = "/Books/BookEditions/AddBookEdition",
                ParentNavigationMenuItemId = 9
            },
            new()
            {
                Id = 12,
                Name = "Book Copies",
                ParentNavigationMenuItemId = 9,
            },
            new()
            {
                Id = 13,
                Name = "All Book Copies",
                Route = "/Books/BookEditions/BookCopies",
                ParentNavigationMenuItemId = 12
            },
            new()
            {
                Id = 14,
                Name = "Add Book Copy",
                Route = "/Books/BookEditions/BookCopies/AddBookCopy",
                ParentNavigationMenuItemId = 12
            }
        };

        builder.HasData(
            employeesRoute
        );
    }
}
