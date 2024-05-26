using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder
            .Property(pu => pu.PublisherName)
            .HasMaxLength(100);

        builder
            .Property(pu => pu.WebsiteAddress)
            .HasMaxLength(100);

        builder
             .OwnsOne(ac => ac.ContactInformation, Helpers.GetContactInformationBuildAction<Publisher>());
    }
}
