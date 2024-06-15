
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Domain.Entities;
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
                Id = 15,
                Name = "Genres",
                ParentNavigationMenuItemId = 6
            },
            new()
            {
                Id = 16,
                Name = "All Genres",
                Route = "/Books/Genres",
                ParentNavigationMenuItemId = 15
            },
            new()
            {
                Id = 17,
                Name = "Add Genre",
                Route = "/Books/Genres/AddGenre",
                ParentNavigationMenuItemId = 15
            },
            new()
            {
                Id = 18,
                Name = "Languages",
                ParentNavigationMenuItemId = 6
            },
            new()
            {
                Id = 19,
                Name = "All Languages",
                Route = "/Books/Languages",
                ParentNavigationMenuItemId = 18
            },
            new()
            {
                Id = 20,
                Name = "Add Language",
                Route = "/Books/Languages/AddLanguage",
                ParentNavigationMenuItemId = 18
            },
            new()
            {
                Id = 21,
                Name = "Author",
                ParentNavigationMenuItemId = 6
            },
            new()
            {
                Id = 22,
                Name = "All Authors",
                Route = "/Books/Authors",
                ParentNavigationMenuItemId = 21
            },
            new()
            {
                Id = 23,
                Name = "Add Author",
                Route = "/Books/Authors/AddAuthor",
                ParentNavigationMenuItemId = 21
            }
        };

        builder.HasData(
            employeesRoute
        );
    }
}
