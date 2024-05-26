using Microsoft.EntityFrameworkCore;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.Infrastructure.Data.Config;

namespace Nika1337.Library.Infrastructure.Data;

public class LibraryContext(DbContextOptions<LibraryContext> options) : DbContext(options)
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
    }
}
