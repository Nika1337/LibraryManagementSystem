using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder
            .Property(ge => ge.Name)
            .HasMaxLength(50);

        builder
            .Property(ge => ge.Description)
            .HasMaxLength(500);

        builder
            .HasMany(ge => ge.Books)
            .WithMany(bk => bk.Genres);
    }
}