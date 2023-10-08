using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rsoi.Lab2.ReservationService.Database;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasIndex(r => r.Id)
            .IsUnique();

        builder.Property(r => r.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(r => r.BooksId)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(r => r.LibraryId)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(r => r.ReservationStatus).IsRequired();
        builder.Property(r => r.Username).IsRequired();
        builder.Property(r => r.StartDate).IsRequired();
        builder.Property(r => r.TillDate).IsRequired();
    }
}