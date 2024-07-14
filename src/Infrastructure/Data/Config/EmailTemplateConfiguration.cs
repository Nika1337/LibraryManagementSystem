using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config
{
    internal class EmailTemplateConfiguration : IEntityTypeConfiguration<EmailTemplate>
    {
        public void Configure(EntityTypeBuilder<EmailTemplate> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(100);

            builder.Property(e => e.Separator)
                .HasMaxLength(10);

            builder.Property(e => e.Subject)
                .HasMaxLength(200);

            builder.Property(e => e.Body)
                .IsRequired();

            builder.Property(e => e.FromEmail)
                .HasMaxLength(100);

        }
    }
}
