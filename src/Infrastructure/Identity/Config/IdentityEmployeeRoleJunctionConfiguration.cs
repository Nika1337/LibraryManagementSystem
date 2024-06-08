using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Infrastructure.Identity.Entities;

namespace Nika1337.Library.Infrastructure.Identity.Config;

internal class IdentityEmployeeRoleJunctionConfiguration : IEntityTypeConfiguration<IdentityEmployeeRoleJunction>
{
    public void Configure(EntityTypeBuilder<IdentityEmployeeRoleJunction> builder)
    {
        builder
            .HasKey(eur => new { eur.UserId, eur.RoleId });

        builder
            .HasOne(eur => eur.User)
            .WithMany(e => e.Roles)
            .HasForeignKey(eur => eur.UserId)
            .IsRequired();

        builder
            .HasOne(eur => eur.Role)
            .WithMany()
            .HasForeignKey(eur => eur.RoleId)
            .IsRequired();
    }
}
