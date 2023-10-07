using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rsoi.Lab2.LibraryService.Database.Models;

namespace Rsoi.Lab2.LibraryService.Database.Configuration;

public class BooksConfiguration : IEntityTypeConfiguration<Books>
{
    public void Configure(EntityTypeBuilder<Books> builder)
    {
        builder.HasKey(b => b.Id);

        builder.HasIndex(b => b.Id)
            .IsUnique();

        builder.Property(b => b.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.HasMany(b => b.LibrariesBooks)
            .WithOne(lb => lb.Books)
            .HasForeignKey(lb => lb.BooksId);

        builder.Property(b => b.Author).IsRequired();
        builder.Property(b => b.Genre).IsRequired();
        builder.Property(b => b.Name).IsRequired();
        builder.Property(b => b.Condition).IsRequired();
    }
}