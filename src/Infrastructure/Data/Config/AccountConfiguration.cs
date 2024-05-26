using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.UseTptMappingStrategy();

        builder
            .Property(ac => ac.AccountName)
            .HasMaxLength(80);

        builder
             .OwnsOne(ac => ac.ContactInformation, Helpers.GetContactInformationBuildAction<Account>());
    }
}
