using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder
            .Property(au => au.Name)
            .HasMaxLength(50);

        builder
            .HasMany(au => au.Books)
            .WithMany(bk => bk.Authors);

        builder
            .Property(au => au.Biography)
            .HasMaxLength(1000);
    }
}