using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rsoi.Lab2.LibraryService.Database.Models;

namespace Rsoi.Lab2.LibraryService.Database.Configuration;

public class LibraryBooksConfiguration : IEntityTypeConfiguration<LibraryBooks>
{
    public void Configure(EntityTypeBuilder<LibraryBooks> builder)
    {
        builder.HasKey(lb => lb.Id);

        builder.HasIndex(lb => lb.Id)
            .IsUnique();

        builder.Property(lb => lb.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(lb => lb.LibraryId).IsRequired();
        builder.Property(lb => lb.BooksId).IsRequired();
        builder.Property(lb => lb.Count).IsRequired();
    }
}