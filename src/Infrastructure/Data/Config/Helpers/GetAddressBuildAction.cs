using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Domain.Entities;
using System;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal static partial class Helpers
{
    public static Action<OwnedNavigationBuilder<T, Address>> GetAddressBuildAction<T>() where T : class
    {
        return ad =>
        {
            ad.WithOwner();

            ad
            .Property(ci => ci.City)
            .HasMaxLength(50);

            ad
            .Property(ci => ci.Street)
            .HasMaxLength(100);

            ad
            .Property(ci => ci.State)
            .HasMaxLength(50);

            ad
            .Property(ci => ci.Country)
            .HasMaxLength(100);

            ad
            .Property(ci => ci.PostalCode)
            .HasMaxLength(10);
        };
    }
}