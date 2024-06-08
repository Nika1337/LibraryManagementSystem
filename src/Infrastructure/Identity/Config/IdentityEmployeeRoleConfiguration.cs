using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Infrastructure.Identity.Entities;
using System;

namespace Nika1337.Library.Infrastructure.Identity.Config;

internal class IdentityEmployeeRoleConfiguration : IEntityTypeConfiguration<IdentityEmployeeRole>
{
    public void Configure(EntityTypeBuilder<IdentityEmployeeRole> builder)
    {
        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<IdentityEmployeeRole> builder)
    {
        builder.HasData(
            new IdentityEmployeeRole
            {
                Name = "Human Resources Manager",
                NormalizedName = "HUMAN RESOURCES MANAGER"
            },
            new IdentityEmployeeRole
            {
                Name = "Operations Manager",
                NormalizedName = "OPERATIONS MANAGER"
            },
            new IdentityEmployeeRole
            {
                Name = "Librarian",
                NormalizedName = "LIBRARIAN"
            },
            new IdentityEmployeeRole
            {
                Name = "Core Librarian",
                NormalizedName = "CORE LIBRARIAN"
            },
            new IdentityEmployeeRole
            {
                Name = "Consultant",
                NormalizedName = "CONSULTANT"
            });
    }

}