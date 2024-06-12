using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class BookCopyConfiguration : IEntityTypeConfiguration<BookCopy>
{
    public void Configure(EntityTypeBuilder<BookCopy> builder)
    {
        builder
            .HasOne(bc => bc.BookEdition)
            .WithMany(be => be.Copies)
            .HasForeignKey("BookEditionId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
