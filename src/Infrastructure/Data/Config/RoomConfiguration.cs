

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.Property(room => room.RoomNumber)
            .HasMaxLength(50);
    }
}
