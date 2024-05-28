using Microsoft.EntityFrameworkCore;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.Infrastructure.Data.Config;
using System;
using System.Linq;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Data;

internal class LibraryContext(DbContextOptions<LibraryContext> options) : DbContext(options)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Bookshelf> Bookshelves { get; set; }
    public DbSet<Shelf> Shelves { get; set; }
    public DbSet<BookEdition> BookEditions { get; set; }
    public DbSet<BookCopy> BookCopies { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<CompanyAccount> CompanyAccounts { get; set; }
    public DbSet<PersonalAccount> PersonalAccounts { get; set; }
    public DbSet<Checkout> Checkouts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new AccountConfiguration());
        builder.ApplyConfiguration(new AuthorConfiguration());
        builder.ApplyConfiguration(new BookConfiguration());
        builder.ApplyConfiguration(new BookCopyConfiguration());
        builder.ApplyConfiguration(new BookEditionConfiguration());
        builder.ApplyConfiguration(new BookshelfConfiguration());
        builder.ApplyConfiguration(new CheckoutConfiguration());
        builder.ApplyConfiguration(new CompanyAccountConfiguration());
        builder.ApplyConfiguration(new GenreConfiguration());
        builder.ApplyConfiguration(new LanguageConfiguration());
        builder.ApplyConfiguration(new PersonalAccountConfiguration());
        builder.ApplyConfiguration(new PublisherConfiguration());
        builder.ApplyConfiguration(new RoomConfiguration());
        builder.ApplyConfiguration(new ShelfConfiguration());

        // Apply global query filters to exclude soft-deleted entities
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (typeof(BaseModel).IsAssignableFrom(entityType.ClrType))
            {
                var method = typeof(LibraryContext)?
                    .GetMethod(nameof(ApplyQueryFilter), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)?
                    .MakeGenericMethod(entityType.ClrType);

                method?.Invoke(null, [builder]);
            }
        }
    }

    private static void ApplyQueryFilter<TEntity>(ModelBuilder modelBuilder) where TEntity : BaseModel
    {
        modelBuilder.Entity<TEntity>().HasQueryFilter(e => e.DeletedDate == null);
    }


    public override int SaveChanges()
    {
        HandleEntityDates();
        return base.SaveChanges();
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        HandleEntityDates();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void HandleEntityDates()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseModel && (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));

        foreach (var entry in entries)
        {
            var entity = (BaseModel)entry.Entity;
            var now = DateTime.UtcNow;

            switch (entry.State)
            {
                case EntityState.Added:
                    entity.CreationDate = now;
                    entity.LastUpdatedDate = now;
                    break;

                case EntityState.Modified:
                    entity.LastUpdatedDate = now;
                    entry.Property(nameof(BaseModel.CreationDate)).IsModified = false; // Prevent updating CreationDate
                    break;

                case EntityState.Deleted:
                    entry.State = EntityState.Modified; // Change state to Modified to perform a soft delete
                    entity.DeletedDate = now;
                    break;
            }
        }
    }
}