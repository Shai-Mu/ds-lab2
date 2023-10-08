using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rsoi.Lab2.RatingService.Database;

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasIndex(r => r.Id)
            .IsUnique();

        builder.Property(r => r.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(r => r.Username)
            .IsRequired();

        builder.Property(r => r.Stars).IsRequired();
    }
}