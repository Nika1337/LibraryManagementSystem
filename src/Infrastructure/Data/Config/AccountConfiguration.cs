using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {

        builder
            .Property(ac => ac.AccountName)
            .HasMaxLength(80);

        builder
            .Property(ac => ac.CustomerIdentification)
            .HasMaxLength(30);

        builder
             .OwnsOne(ac => ac.ContactInformation, Helpers.GetContactInformationBuildAction<Account>());
    }
}
