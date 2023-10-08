using Microsoft.EntityFrameworkCore;

namespace Rsoi.Lab2.RatingService.Database;

#nullable disable
public class RatingContext : DbContext
{
    public DbSet<Rating> Ratings { get; set; }

    public RatingContext(DbContextOptions<RatingContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new RatingConfiguration());
    }
}
#nullable restore