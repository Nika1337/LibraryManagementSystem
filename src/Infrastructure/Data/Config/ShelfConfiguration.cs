

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class ShelfConfiguration : IEntityTypeConfiguration<Shelf>
{
    public void Configure(EntityTypeBuilder<Shelf> builder)
    {
        builder
            .HasOne(sh => sh.Bookshelf)
            .WithMany(bs => bs.Shelves)
            .HasForeignKey("BookshelfId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
