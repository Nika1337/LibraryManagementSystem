using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

public class BookEditionCopiesAuditEntryConfiguration : IEntityTypeConfiguration<BookEditionCopiesAuditEntry>
{
    public void Configure(EntityTypeBuilder<BookEditionCopiesAuditEntry> builder)
    {
        builder
            .HasMany(becae => becae.BookCopies)
            .WithMany();
    }
}
