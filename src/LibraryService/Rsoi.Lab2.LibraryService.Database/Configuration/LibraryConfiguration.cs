using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rsoi.Lab2.LibraryService.Database.Models;

namespace Rsoi.Lab2.LibraryService.Database.Configuration;

public class LibraryConfiguration : IEntityTypeConfiguration<Library>
{
    public void Configure(EntityTypeBuilder<Library> builder)
    {
        builder.HasKey(l => l.Id);

        builder.HasIndex(l => l.Id)
            .IsUnique();

        builder.Property(l => l.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.HasMany(l => l.LibrariesBooks)
            .WithOne(lb => lb.Library)
            .HasForeignKey(lb => lb.LibraryId);

        builder.Property(l => l.Name).IsRequired();
        builder.Property(l => l.City).IsRequired();
        builder.Property(l => l.Address).IsRequired();
    }
}