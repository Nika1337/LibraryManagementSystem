
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class BookshelfConfiguration : IEntityTypeConfiguration<Bookshelf>
{
    public void Configure(EntityTypeBuilder<Bookshelf> builder)
    {
        builder
            .HasOne(bs => bs.Room)
            .WithMany(rm => rm.Bookshelves)
            .HasForeignKey("RoomId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
