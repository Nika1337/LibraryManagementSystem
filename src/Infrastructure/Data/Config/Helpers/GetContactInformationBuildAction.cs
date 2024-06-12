using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Domain.Entities;
using System;


namespace Nika1337.Library.Infrastructure.Data.Config;

internal static partial class Helpers
{
    public static Action<OwnedNavigationBuilder<T, ContactInformation>> GetContactInformationBuildAction<T>() where T : class
    {
        return ci =>
        {
            ci.WithOwner();

            ci
            .Property(ci => ci.Email)
            .HasMaxLength(255);

            ci
            .Property(ci => ci.PhoneNumber)
            .HasMaxLength(20);

            ci.OwnsOne(ci => ci.Address, GetAddressBuildAction<ContactInformation>());
        };
    }
}

