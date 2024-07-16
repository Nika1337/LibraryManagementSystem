

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class CheckoutConfiguration : IEntityTypeConfiguration<Checkout>
{
    public void Configure(EntityTypeBuilder<Checkout> builder)
    {
        builder
            .HasOne(ch => ch.Account)
            .WithMany(ac => ac.Checkouts)
            .HasForeignKey("AccountId")
            .OnDelete(DeleteBehavior.Restrict);


        builder.ToTable(ch =>
        {
            ch.HasCheckConstraint("CK_ReturnMoreThanCheckout", "[SupposedReturnTime] > [CheckoutTime]");
        });
    }
}
