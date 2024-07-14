
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class BookEditionConfiguration : IEntityTypeConfiguration<BookEdition>
{
    public void Configure(EntityTypeBuilder<BookEdition> builder)
    {
        builder
            .Property(be => be.Isbn)
            .HasMaxLength(20);

        builder
            .HasOne(bk => bk.Language)
            .WithMany()
            .HasForeignKey("LanguageId")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(be => be.Publisher)
            .WithMany(pu => pu.PublishedBookEditions)
            .HasForeignKey("PublisherId")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(be => be.Room)
            .WithMany(r => r.BookEditions)
            .HasForeignKey("RoomId")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(be => be.Book)
            .WithMany(bk => bk.Editions)
            .HasForeignKey("BookId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
