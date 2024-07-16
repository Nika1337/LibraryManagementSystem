using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Infrastructure.Data.Config;
using Nika1337.Library.Infrastructure.Logging.Audit;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Data;

internal class LibraryContext(
    IHttpContextAccessor httpContextAccessor,
    DbContextOptions<LibraryContext> options) : DbContext(options)
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    public DbSet<Author> Authors { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<BookEdition> BookEditions { get; set; }
    public DbSet<BookCopy> BookCopies { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Checkout> Checkouts { get; set; }
    public DbSet<EmailTemplate> EmailTemplates { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<Genre> Genre { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new AuditLogConfiguration());
        builder.ApplyConfiguration(new EmailTemplateConfiguration());
        builder.ApplyConfiguration(new AccountConfiguration());
        builder.ApplyConfiguration(new AuthorConfiguration());
        builder.ApplyConfiguration(new BookConfiguration());
        builder.ApplyConfiguration(new BookCopyConfiguration());
        builder.ApplyConfiguration(new BookEditionConfiguration());
        builder.ApplyConfiguration(new CheckoutConfiguration());
        builder.ApplyConfiguration(new GenreConfiguration());
        builder.ApplyConfiguration(new LanguageConfiguration());
        builder.ApplyConfiguration(new PublisherConfiguration());
        builder.ApplyConfiguration(new RoomConfiguration());
        builder.ApplyConfiguration(new BookCopyCheckoutConfiguration());

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        LogModifiedEntities();

        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        LogModifiedEntities();

        return base.SaveChanges();
    }


    private void LogModifiedEntities()
    {
        LoggingHelper.LogModifiedEntities(
            ChangeTracker,
            _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!,
            AuditLogs);
    }
}