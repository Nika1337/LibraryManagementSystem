
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder
            .Property(bk => bk.Title)
            .HasMaxLength(100);

        builder
            .Property(bk => bk.Summary)
            .HasMaxLength(300);

        builder
            .HasOne(bk => bk.OriginalLanguage)
            .WithMany()
            .HasForeignKey("OriginalLanguageId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
