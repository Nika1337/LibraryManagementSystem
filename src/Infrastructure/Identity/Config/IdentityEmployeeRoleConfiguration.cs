using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nika1337.Library.Infrastructure.Identity.Config;

internal class IdentityEmployeeRoleConfiguration : IEntityTypeConfiguration<IdentityEmployeeRole>
{
    private static readonly Dictionary<IdentityEmployeeRole, int[]> roleToNavItemIdsDictionary = new()
    {
        {
            new IdentityEmployeeRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Human Resources Manager",
                NormalizedName = "HUMAN RESOURCES MANAGER"
            },
            [1, 2, 3]
        },
        {
            new IdentityEmployeeRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            },
            []
        },
        {
            new IdentityEmployeeRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Librarian",
                NormalizedName = "LIBRARIAN"
            },
            []
        },
        {
            new IdentityEmployeeRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Core Librarian",
                NormalizedName = "CORE LIBRARIAN"
            },
            []
        },
        {
            new IdentityEmployeeRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Consultant",
                NormalizedName = "CONSULTANT"
            },
            []
        }
    };
    public void Configure(EntityTypeBuilder<IdentityEmployeeRole> builder)
    {
        SeedData(builder);

        ConfigureRoleToNavItemRelationship(builder);
    }

    private static void SeedData(EntityTypeBuilder<IdentityEmployeeRole> builder)
    {
        builder.HasData(roleToNavItemIdsDictionary.Keys.ToArray());
    }

    private static void ConfigureRoleToNavItemRelationship(EntityTypeBuilder<IdentityEmployeeRole> builder)
    {
        builder.HasMany(role => role.NavigationMenuItems)
               .WithMany()
               .UsingEntity(j => j.HasData(GetJunctionData()));
    }

    private static object[] GetJunctionData()
    {
        var roleNavItemJunctionData =  roleToNavItemIdsDictionary.SelectMany(
            roleToNavItemsPair => roleToNavItemsPair.Value.Select(navItemId => new
            {
                IdentityEmployeeRoleId = roleToNavItemsPair.Key.Id,
                NavigationMenuItemsId = navItemId,
            })
        ).ToArray();

        return roleNavItemJunctionData;
    }
}