
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.ApplicationCore.Entities;
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

        SeedData(builder);
    }

    private void SeedData(EntityTypeBuilder<NavigationMenuItem> builder)
    {
        var employeesRoute = new List<NavigationMenuItem> {
            new() {
                Id = 1,
                Name = "Employees",
                Route = "/EmployeeManagement/AllEmployees"
            },
            new()
            {
                Id = 2,
                Name = "All Employees",
                Route = "/EmployeeManagement/AllEmployees",
                ParentNavigationMenuItemId = 1
            },
            new()
            {
                Id = 3,
                Name = "Register Employee",
                Route = "/EmployeeManagement/RegisterEmployee",
                ParentNavigationMenuItemId = 1
            }
        };

        builder.HasData(
            employeesRoute
        );
    }
}
