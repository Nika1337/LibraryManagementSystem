using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class CompanyAccountConfiguration : IEntityTypeConfiguration<CompanyAccount>
{
    public void Configure(EntityTypeBuilder<CompanyAccount> builder)
    {
        builder
            .Property(ca => ca.CompanyName)
            .HasMaxLength(80);

        builder
            .Property(ca => ca.WebsiteAddress)
            .HasMaxLength(100);
    }
}
