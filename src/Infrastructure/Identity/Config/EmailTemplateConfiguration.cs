using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Identity.Config
{
    internal class EmailTemplateConfiguration : IEntityTypeConfiguration<EmailTemplate>
    {
        public void Configure(EntityTypeBuilder<EmailTemplate> builder)
        {
            // Configure the Name property
            builder.Property(e => e.Name)
                .HasMaxLength(100); // Adjust the max length as necessary

            // Configure the Separator property
            builder.Property(e => e.Separator)
                .HasMaxLength(10); // Adjust the max length as necessary

            // Configure the Subject property
            builder.Property(e => e.Subject)
                .HasMaxLength(200); // Adjust the max length as necessary

            // Configure the Body property
            builder.Property(e => e.Body)
                .IsRequired();

            // Configure the FromEmail property
            builder.Property(e => e.FromEmail)
                .HasMaxLength(100); // Adjust the max length as necessary

        }
    }
}
