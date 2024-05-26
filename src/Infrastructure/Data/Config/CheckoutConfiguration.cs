

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class CheckoutConfiguration : IEntityTypeConfiguration<Checkout>
{
    public void Configure(EntityTypeBuilder<Checkout> builder)
    {
        builder
            .HasOne(ch => ch.Account)
            .WithMany()
            .HasForeignKey("AccountId")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(ch => ch.BookCopy)
            .WithMany()
            .HasForeignKey("BookCopyId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(ch =>
        {
            ch.HasCheckConstraint("CK_ReturnMoreThanCheckout", "[SupposedReturnTime] > [CheckoutTime]");
            ch.HasCheckConstraint("CK_CloseMoreThanCheckout", "[CheckoutCloseTime] > [CheckoutTime]");
            ch.HasCheckConstraint("CK_CloseTimeWithStatus", "([CheckoutStatus] IS NULL AND [CheckoutCloseTime] IS NULL) OR ([CheckoutStatus] IS NOT NULL AND [CheckoutCloseTime] IS NOT NULL)");
        });
    }
}
