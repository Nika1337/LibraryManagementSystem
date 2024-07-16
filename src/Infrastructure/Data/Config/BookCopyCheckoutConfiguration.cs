
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class BookCopyCheckoutConfiguration : IEntityTypeConfiguration<BookCopyCheckout>
{
    public void Configure(EntityTypeBuilder<BookCopyCheckout> builder)
    {
        builder.HasKey("CheckoutId", "BookCopyId");

        builder
            .HasOne(bcc => bcc.BookCopy)
            .WithMany(bc => bc.BookCopyCheckouts)
            .HasForeignKey("BookCopyId")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(bcc => bcc.Checkout)
            .WithMany(c => c.BookCopyCheckouts)
            .HasForeignKey("CheckoutId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable( bcc =>
        {
            bcc.HasCheckConstraint("CK_CloseTimeWithStatus", "([BookCopyCheckoutStatus] IS NULL AND [BookCopyCheckoutCloseTime] IS NULL) OR ([BookCopyCheckoutStatus] IS NOT NULL AND [BookCopyCheckoutCloseTime] IS NOT NULL)");
        });
    }
}
