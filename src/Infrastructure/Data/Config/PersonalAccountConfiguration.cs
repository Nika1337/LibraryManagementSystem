
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class PersonalAccountConfiguration : IEntityTypeConfiguration<PersonalAccount>
{
    public void Configure(EntityTypeBuilder<PersonalAccount> builder)
    {
        builder
            .Property(pa => pa.FirstName)
            .HasMaxLength(30);

        builder
            .Property (pa => pa.LastName)
            .HasMaxLength(50);

        builder
            .Property(pa => pa.IdNumber)
            .HasMaxLength(20);

    }
}
