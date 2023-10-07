using Microsoft.EntityFrameworkCore;
using Rsoi.Lab2.LibraryService.Database.Configuration;
using Rsoi.Lab2.LibraryService.Database.Models;

namespace Rsoi.Lab2.LibraryService.Database;

#nullable disable
public class LibraryContext : DbContext
{
    public DbSet<Books> Books { get; set; }
    
    public DbSet<Library> Libraries { get; set; }
    
    public DbSet<LibraryBooks> LibraryBooks { get; set; }

    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new BooksConfiguration());
        builder.ApplyConfiguration(new LibraryConfiguration());
        builder.ApplyConfiguration(new LibraryBooksConfiguration());
    }
}
#nullable restore